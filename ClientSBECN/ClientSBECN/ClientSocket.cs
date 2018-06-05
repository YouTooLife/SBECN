using System;
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

namespace ClientSBECN
{
    class ClientSocket
    {

        byte[] bytes = new byte[1024];

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;

        RichTextBox rtb = null;
        CheckedListBox clb;
        Socket sender;

        RSA rsa = null;

        public string result = "";

        public List<string> voters = null;

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
         

                Byte[] SendBytes = Encoding.Default.GetBytes((rsa != null) ? eMsg : message);
                sender.Send(SendBytes);
                string s = Encoding.Default.GetString(SendBytes.ToArray());
                Console.Out.Write("\nTracieve: " + s + "\n");
                Receiver();
                sender.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SendMessage(string message, bool accept)
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


                Byte[] SendBytes = Encoding.Default.GetBytes((rsa != null) ? eMsg : message);
                sender.Send(SendBytes);
                string s = Encoding.Default.GetString(SendBytes.ToArray());
                Console.Out.Write("\nTracieve: " + s + "\n");
                if (accept)
                    Receiver();
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
            string[] msg = message.Split('[');
            if (msg[0] == "PublicKey")
            {
                Console.Out.Write("\nEps:" + msg[1] + "\n");
                Console.Out.Write("\nN: " + msg[2] + "\n");
                
                if (rtb != null)
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    string[] pers = msg[3].Split(']');
                    Console.Out.WriteLine(pers);
                    for (int i = 0; i < pers.Length-1; i++)
                    {
                        clb.Invoke((MethodInvoker)delegate ()
                       {
                           clb.Items.Add(pers[i].Split('|')[0], false);
                       });
                        Console.Out.WriteLine(pers[i].Split('|')[0] + "\n" + pers[i].Split('|')[1] + "\n");
                        rtb.Text += pers[i].Split('|')[0] + "\n" + pers[i].Split('|')[1] + "\n";
                    }
                });

                rsa = new RSA(BigInteger.Parse(msg[1]), BigInteger.Parse(msg[2]));
            }
            if (msg[0] == "Error")
            {
                MessageBox.Show(msg[1]);
                ClientClose();
            }
            if (msg[0] == "Answer")
            {
                Form1.index = Convert.ToInt32(msg[2]);
                MessageBox.Show(msg[1]+"\nПозиция: "+ msg[2]);
                //ClientClose();

            }
            if (msg[0] == "vAnswer")
            {
                if (rtb != null)
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n"+ msg[1]+ "\n";
                });
                Form1.canVoite = true;
                //ClientClose();
            }
                if (msg[0] == "Result")
            {
                result = msg[1];
                //ClientClose();
            }

        }

        public void  ClientClose()
        {
            sender.Close();
        }
        public ClientSocket(string host, int h, int port, RichTextBox rtb, CheckedListBox clb)
        {
            this.clb = clb;
            this.rtb = rtb;

            ipHost = Dns.GetHostEntry(host);
            ipAddr = ipHost.AddressList[h];
            ipEndPoint = new IPEndPoint(ipAddr, port);

            SendMessage("getPublicKey");
        }

        public ClientSocket(string host, int port)
        {
            try {
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
            }catch(System.Exception ex)
            {
                MessageBox.Show("Errr" +ex.Message);
            }
       }

        public ClientSocket(string host, int port, RichTextBox rtb)
        {
            this.rtb = rtb;
            try
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
            catch (System.Exception ex)
            {
                MessageBox.Show("Errr" + ex.Message);
            }
        }

    }
            
 }

    
