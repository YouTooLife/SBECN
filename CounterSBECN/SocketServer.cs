using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace CounterSBECN
{
    public class SocketServer
    {
        bool isListen = false;

        public void SendAnswer(Socket ReceiveSocket, string s)
        {

            if (s.Contains("voite") && !endVoters.Contains(s.Split('[')[2]))
            {
                SendMessage("vAnswer[from Counter: принято!", ReceiveSocket);
                ReceiveSocket.Close();

                endVoters.Add(s.Split('[')[2]);
                string[] allMessage = s.Split('[')[1].Split(']');
                for (int i = 0; i < allMessage.Length-1; i++)
                {
                    string message = rsa.Decrypt(allMessage[i]);
                    Console.Out.WriteLine(message);
                    voites.Add(message);
                    rtb.Invoke((MethodInvoker)delegate ()
                    {
                        rtb.Text += "\n" + message + "\n";
                    });
                    string[] msg = message.Split('|');

                    for (int k = 1; k < msg.Length; k++)
                    {
                        result[k - 1] += Convert.ToInt32(msg[k]);
                       
                    }
                }

                if (voites != null)
                {
                    if (((voters.Length-1) * 2 * (voters.Length-1)) == voites.Count)
                    {
                        rtb.Invoke((MethodInvoker)delegate ()
                        {
                        Console.Out.WriteLine("done");
                        rtb.Text += "Итоги: ";
                        });
                        for (int k = 0; k < result.Length; k++)
                        {
                            rtb.Invoke((MethodInvoker)delegate ()
                            {
                                rtb.Text += "\n" + person[k].Split('|')[0] + ": "+ result[k];
                            });
                            if (result[k] > max)
                                {
                                    indexPerson = k;
                                    max = result[indexPerson];
                                }
                          }
                        rtb.Invoke((MethodInvoker)delegate ()
                        {
                            rtb.Text += "\n\nПобедитель: "+ person[indexPerson].Split('|')[0];
                        });


                        for (int i = 0; i < voters.Length-1; i++)
                        {

                            RSA vRSA = new RSA(BigInteger.Parse(votersKey[i].Split('|')[0]),
                                BigInteger.Parse(votersKey[i].Split('|')[1]));
                            ClientSocket client = new ClientSocket(voters[i], Convert.ToInt32(votersPort[i]));
                            client.SendMessage(vRSA.Encrypt("Answer[Голосование завершено![Победитель: "+ person[indexPerson].Split('|')[0]),false);
                            client.ClientClose();
                            
                        }
                       
                    }
                }
                
            }
            else
            {
                Console.Out.WriteLine(s);
                string message = rsa.Decrypt(s);
                Console.Out.WriteLine(message);
                string[] msg = message.Split('[');

                if (msg[0] == "voters")
                {
                    Console.Out.WriteLine(msg[0]);
                    voters = msg[1].Split(']');
                    Console.Out.WriteLine(msg[1]);
                    votersPort = msg[2].Split(']');
                    Console.Out.WriteLine(msg[2]);
                    votersKey = msg[3].Split(']');
                    Console.Out.WriteLine(msg[3]);
                    strPerson = msg[4];
                    Console.Out.WriteLine(msg[4]);
                    person = strPerson.Split(']');

                    result = new int[person.Length - 1];
                    result.Initialize();

                    rtb.Invoke((MethodInvoker)delegate ()
                    {
                        rtb.Text += "Пакеты голосов: \n";
                    });
                }
            }

            

        }

        public void Revoite()
        {
            for (int i = 0; i < voters.Length - 1; i++)
            {

                RSA vRSA = new RSA(BigInteger.Parse(votersKey[i].Split('|')[0]),
                    BigInteger.Parse(votersKey[i].Split('|')[1]));
                ClientSocket client = new ClientSocket(voters[i], Convert.ToInt32(votersPort[i]));
                client.SendMessage(vRSA.Encrypt("revoite[777me"), false);

            }
        }

        public void ListenSocket()
        {
            // Начинаем слушать соединения
            while (isListen)
                {
                // Программа приостанавливается, ожидая входящее соединение
                try
                {
                    Socket ReceiveSocket = sListener.Accept();
                    //Пришло сообщение
                    Byte[] Receive = new Byte[256];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //и записываем в поток
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceiveSocket.Available > 0);
                        string s = Encoding.Default.GetString(MessageR.ToArray());
                        Console.Out.WriteLine("\nReceived: " + s + "\n");
                        
                        ///Answer
                        SendAnswer(ReceiveSocket, s);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }
        public void SendMessage(string message, Socket sender)
        {
            try
            {
                Byte[] SendBytes = Encoding.Default.GetBytes(message);
                sender.Send(SendBytes);
        
               
                string s = Encoding.Default.GetString(SendBytes.ToArray());

                Console.Out.WriteLine("\nTracieve: " + s + "\n");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ServerClose()
        {
            sListener.Close();
        }

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;
        public Socket sListener;
        RichTextBox rtb;

        public RSA rsa;

        string strPerson = "";
        string[] person;

        int[] result;
        int indexPerson = 0, max = 0;

        List<string> voites = new List<string>();
        List<string> endVoters = new List<string>();

        string[] voters = null;
        string[] votersPort = null;
        string[] votersKey = null;

        string secretKey = "123qwe";

        public SocketServer(string host, int h, int port, RichTextBox rtb)
        {

            this.rtb = rtb;
            ipHost = Dns.GetHostEntry(host);
            foreach (IPAddress adr in ipHost.AddressList)
            Console.Out.WriteLine(adr);
            ipAddr = ipHost.AddressList[h];
            ipEndPoint = new IPEndPoint(ipAddr, port);
 
            // Create socket TCP/IP
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(100);

            // Create RSA key 
            rsa = new RSA();

            isListen = true;

            //Console.WriteLine("My local IpAddress is :" + IPAddress.Parse(((IPEndPoint)sListener.LocalEndPoint).Address.ToString()) + "I am connected on port number " + ((IPEndPoint)sListener.LocalEndPoint).Port.ToString());
            //Console.WriteLine("I am connected to " + IPAddress.Parse(((IPEndPoint)sListener.RemoteEndPoint).Address.ToString()) + "on port number " + ((IPEndPoint)sListener.RemoteEndPoint).Port.ToString());
        }
    }
}
