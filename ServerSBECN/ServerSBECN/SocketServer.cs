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

namespace ServerSBECN
{
    public class SocketServer
    {
        bool isListen = false;

        public void SendAnswer(Socket ReceiveSocket, string s)
        {

            if (s.Contains("counter"))
            {
                string[] mes = s.Split('[');
                counterAddress = IPAddress.Parse(((IPEndPoint)ReceiveSocket.RemoteEndPoint).Address.ToString()) +"|"+ mes[1];
                counterPK = mes[2];
                counterN = mes[3];
                if (counterRSA == null)
                    counterRSA = new RSA(BigInteger.Parse(counterPK),BigInteger.Parse(counterN));
                SendMessage("Answer[Успешное подключение!", ReceiveSocket);
                if (pasports.Count == Voters.Count && counterAddress != "")
                {
                    ClientSocket client2 = new ClientSocket(counterAddress, 1013);
                    client2.SendMessage(counterRSA.Encrypt("voters[" + votersString + "[" + votersPort + "[" +votersKey+ "["+strPerson));
                    client2.ClientClose();
                    for (int i = 0; i < voters.Count; i++)
                    {
                        ClientSocket client = new ClientSocket(voters[i].Split('[')[0], Convert.ToInt32(voters[i].Split('[')[1]));
                        client.SendMessage("voters[" + votersString + "[" + votersPort + "[" + counterAddress+"["+counterPK+"["+counterN+"["+votersKey);
                        client.ClientClose();
                    }
                }
            }
            else
            if (s == "getPublicKey")
            { 
                SendMessage("PublicKey[" + rsa.eps.ToString() + "["
                    + rsa.n.ToString() + "[" + strPerson, ReceiveSocket);
            }
            else
            {
                string message = rsa.Decrypt(s);
                string[] mes = message.Split('[');

                /*if (mes[0] == "getResult")
                {
                    if (pasports.Contains(mes[1]))
                    {
                        int allVoites = 0;
                        for (int i = 0; i < result.Length; i++)
                            allVoites += result[i];

                        string tMsg = "";
                        int max = 0, index = 0;
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i] > max)
                            {
                                max = result[i];
                                index = i;
                            }
                            tMsg += strPerson.Split('[')[i + 1].Split('|')[0]
                                + " - " + result[i] + " - "
                                + (float)(100.0 / (float)allVoites * (float)result[i]) + "%\n";
                        }
                        tMsg += "\n ЛИДИРУЕТ: " + strPerson.Split('[')[index + 1].Split('|')[0];
                        SendMessage("Result[" + tMsg, ReceiveSocket);
                    }
                    else
                    {
                        SendMessage("Error[Проголосуйте, чтобы посмотреть результат!", ReceiveSocket);
                    }
                }*/
                if (mes[0] == "voite")
                {

                    if (pasports.Contains(mes[1]))
                        SendMessage("Error[Вы уже голосовали!", ReceiveSocket);
                    else
                    {
                        if (Voters.Contains(mes[1]))
                        {
                            clients.Add(ReceiveSocket);

                            pasports.Add(mes[1]);
                            Console.Out.WriteLine(mes[1]+" "+mes[2]+" "+mes[3]);
                            voters.Add(IPAddress.Parse(((IPEndPoint)ReceiveSocket.RemoteEndPoint).Address.ToString()) +"|"+ mes[2] + "[" + mes[3]);
                            votersString += IPAddress.Parse(((IPEndPoint)ReceiveSocket.RemoteEndPoint).Address.ToString()) + "|" + mes[2] + "]";
                            votersPort += mes[3]+"]";
                            votersKey += mes[4] + "]";
                            Console.Out.WriteLine(votersString);
                            SendMessage("Answer[Вы добавлены в очередь для голосования!["+(clients.Count-1), ReceiveSocket);
                            rtb.Invoke((MethodInvoker)delegate ()
                            {
                                rtb.Text += "\n|-------|" + mes[1] + "\n" + mes[2] + "\n";
             
                            });


                            if (pasports.Count == Voters.Count && counterAddress != "")
                            {
                                ClientSocket client2 = new ClientSocket(counterAddress, 1013);
                                client2.SendMessage(counterRSA.Encrypt(("voters[" + votersString + "[" + votersPort + "[" + votersKey + "[" + strPerson)));
                                client2.ClientClose();
                                for (int i = 0; i < voters.Count; i++)
                                {
                                    ClientSocket client = new ClientSocket(voters[i].Split('[')[0], Convert.ToInt32(voters[i].Split('[')[1]));
                                    client.SendMessage("voters[" + votersString + "[" + votersPort + "[" + counterAddress + "[" + counterPK + "[" + counterN+"["+votersKey);
                                    client.ClientClose();
                                }
                            }
                        } 
                        else
                        {
                            SendMessage("Error[У Вас не прав голосовать!", ReceiveSocket);
                        }
                        
                    }
                }
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

                        rtb.Invoke((MethodInvoker)delegate ()
                       {
                           rtb.Text += "\nReceived: " + s + "\n";
                       });
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
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\nTracieve: " + s + "\n";
                });
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
        Socket sListener;
        RichTextBox rtb;

        RSA rsa;
        RSA counterRSA = null;

        string strPerson = "";
        List<string> voters = new List<string>();
        List<string> pasports = new List<string>();
        List<string> Voters = new List<string>();

        string votersString = "";
        string votersPort = "";
        string votersKey = "";
        string counterAddress = "";


        List<Socket> clients = new List<Socket>();
        Socket counterSocket = null;

        string counterPK = "";
        string counterN = "";

        string secretKey = "123qwe";

        public SocketServer(string host, int h, int port, RichTextBox rtb)
        {

            List<string> person = Form1.person;
            Voters = Form1.person2;

            for (int i = 0; i < person.Count; i++)
                strPerson +=  person[i]+ "]" ;

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
