﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSBECN
{
    class ClientSocket
    {

        byte[] bytes = new byte[1024];

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;

        Socket sender;

        RSA rsa = null;

        public void SendMessage(string message)
        {
            try
            {
                string eMsg = "";
                if (rsa != null)
                {
                    eMsg = rsa.Encrypt(message);
                }

                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);
                Console.WriteLine("My local IpAddress is :" + IPAddress.Parse(((IPEndPoint)sender.LocalEndPoint).Address.ToString()) + "I am connected on port number " + ((IPEndPoint)sender.LocalEndPoint).Port.ToString());
                Console.WriteLine("I am connected to " + IPAddress.Parse(((IPEndPoint)sender.RemoteEndPoint).Address.ToString()) + "on port number " + ((IPEndPoint)sender.RemoteEndPoint).Port.ToString());

                Byte[] SendBytes = Encoding.Default.GetBytes((rsa != null) ? eMsg : message);
                sender.Send(SendBytes);
                string s = Encoding.Default.GetString(SendBytes.ToArray());
                Console.Out.Write("\nTracieve: " + s + "\n");
                //Receiver();
                sender.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Receiver()
        {
                try
                {
                    Byte[] Receive = new Byte[256];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        do
                        {//Собственно читаем 
                            ReceivedBytes = sender.Receive(Receive, Receive.Length, 0);
                            //и записываем в поток
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (sender.Available > 0);

                    Console.Out.Write("\nReceived: " + Encoding.Default.GetString(MessageR.ToArray()) + "\n");
                        hendler(Encoding.Default.GetString(MessageR.ToArray()));
                        
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void hendler(string message)
        {
           

        }

        public void  ClientClose()
        {
            sender.Close();
        }
 
        public ClientSocket(string host, int port)
        {

            ipHost = Dns.GetHostEntry(host.Split('|')[0]);
            for (int i = 0; i < ipHost.AddressList.Count(); i++)
            {
                Console.Out.WriteLine(ipHost.AddressList[i].ToString() + " " + host.Split('|')[1]);
                if (ipHost.AddressList[i].ToString() == host.Split('|')[1])
                {

                    ipAddr = ipHost.AddressList[i];
                    break;
                }
            }
            ipEndPoint = new IPEndPoint(ipAddr, port);
        }
    }
}
