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

namespace ClientSBECN
{
    public class SocketServer
    {
        bool isListen = false;
        String MVoite = "";
        int num = 0;

        public string RandomString(int length)
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@%&*$#";
            StringBuilder res = new StringBuilder();

            while (0 < length--)
            {
                res.Append(valid[rand.Next(valid.Length)]);
            }
            return res.ToString();
        }


        public void changeVoite()
        {

            int[] first = new int[nk];
            int[] second = new int[first.Length];

            for (int j = 0; j < nk; j++)
            {
                first[j] = rand.Next(n*4 + 1) - n*2;
                second[j] = ((myV) != j ? -first[j] : 1 - first[j]);
            }

            for (int k = 0; k < n; k++)
            {
                int[] vote = new int[nk];
                for (int j = 0; j < nk; j++)
                {
                    if (k + 1 != n && first[j] != 0)
                    {
                        vote[j] = rand.Next(first[j] > 3 ? 4+1 : Math.Abs(first[j])+1);
                    }
                    else
                        vote[j] = Math.Abs(first[j]);
                    if (first[j] < 0) vote[j] *= -1;
                    first[j] -= vote[j];
                }
                int[] vote2 = new int[nk];
                for (int j = 0; j < nk; j++)
                {
                    if (k + 1 != n && second[j] != 0)
                    {
                        vote2[j] = rand.Next(second[j] > 3 ? 4+1 : Math.Abs(second[j])+1);
                    }
                    else
                        vote2[j] = Math.Abs(second[j]);
                    if (second[j] < 0) vote2[j] *= -1;
                    second[j] -= vote2[j];
                }
                string pVote = RandomString(20);

                    foreach (int b in vote)
                    pVote += "|" + b;
                myVoters.Add(pVote);
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\n" + pVote;
                    pVote = RandomString(20);
                    foreach (int b in vote2)
                        pVote += "|" + b;
                    myVoters.Add(pVote);
                    rtb.Text += "\n" + pVote;
                });
            }

        }

        public void SendAnswer(Socket ReceiveSocket, string s)
        {
            Console.Out.WriteLine("Reciveing...");
            if (voters == null)
            {
                string[] mes = s.Split('[');
                if (mes[0] == "voters")
                {
                    Console.Out.WriteLine(mes[0]);
                    voters = mes[1].Split(']');
                    votersPort = mes[2].Split(']');
                    counterAddress = mes[3];
                    counterK = mes[4];
                    counterN = mes[5];
                    votersKey = mes[6].Split(']');

                    Console.Out.WriteLine(mes[6]);

                    counterRSA = new RSA(BigInteger.Parse(counterK),BigInteger.Parse(counterN));




                    n = voters.Length - 1;

                    changeVoite();

                    if (Form1.index == 0)
                    {
                         Thread send = new Thread(delegate () { sendVoite(); });
                         send.IsBackground = true;
                         send.Start();

                    }
                }
            }
            else
            {
                    string message = myRSA.Decrypt(s);

                    string[] mes = message.Split('[');

                if (mes[0] == "revoite" && mes[1] != "777me")
                {
                    Revoite();
                    ReceiveSocket.Close();
                    return;
                }
                if (mes[0] == "revoite" && mes[1] == "777me")
                {
                    Thread send = new Thread(delegate () { SendToServ(); });
                    send.IsBackground = true;
                    send.Start();
                    ReceiveSocket.Close();
                    return;
                }

                if (mes[0] == "canVoite")
                {
                    SendMessage("vAnswer[id: " + Form1.index + " - принято! (голосую)", ReceiveSocket);
                    ReceiveSocket.Close();

                    Thread send = new Thread(delegate () { sendVoite(); });
                    send.IsBackground = true;
                    send.Start();


                }

                if (mes[0] == "sendServ")
                //if (voitesCount == n * 2)
                {
                    SendMessage("vAnswer[id: " + Form1.index + " - принято! (отвправка счетчику)", ReceiveSocket);
                    ReceiveSocket.Close();

                    Thread send = new Thread(delegate () { SendToServ(); });
                    send.IsBackground = true;
                    send.Start();

                }

                if (mes[0] == "voite")
                    {

                        voitesCount++;
                        voites += mes[1] + "]";

                    rtb.Invoke((MethodInvoker) delegate() {
                        rtb.Text += "\n\nВходящий пакет " + "№"+voitesCount
                        +"\n"+ mes[1];
                    });
                    SendMessage("vAnswer[id: "+Form1.index+" - принято! (пакет голоса)",ReceiveSocket);
                    ReceiveSocket.Close();
                    }

                    if (mes[0] == "Answer")
                    {
                    ReceiveSocket.Close();
                    MessageBox.Show(mes[1]);
                    rtb2.Invoke((MethodInvoker)delegate () {
                        rtb2.Text += "\n" + mes[2];
                    });
                }

            }
        }

        public void  SendServ()
        {
            ClientSocket sender = new ClientSocket(counterAddress, 1013, Form1.rtb);
            sender.SendMessage("voite[" + voites + "[" + Form1.index, true);
            sender.ClientClose();
        }

        public void SendToServ()
        {
            rtb.Invoke((MethodInvoker)delegate ()
            {
                rtb.Text += "\n\nИсходящий пакет (счетчику)";
            });

            Form1.canVoite = false;
            Thread send = new Thread(delegate () { SendServ(); });
            send.IsBackground = true;
            send.Start();

            Form1.time = 0;
            while (!Form1.canVoite)
            {
                if (Form1.time == 2)
                {
                    Form1.time = 0;
                    Thread send2 = new Thread(delegate () { SendServ(); });
                    send2.IsBackground = true;
                    send2.Start();
                    rtb.Invoke((MethodInvoker)delegate ()
                    {
                        rtb.Text += "\n\nИсходящий пакет (серверу) (повтор)";
                    });
                }
            }


            if (Form1.index+1 < n)
            {
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\nСледующий на очереди к счетчику id: "+ (Form1.index + 1);
                });
                RSA clientRSA = new RSA(
                   BigInteger.Parse(votersKey[Form1.index + 1].Split('|')[0]),
                   BigInteger.Parse(votersKey[Form1.index + 1].Split('|')[1]));
                ClientSocket sender2
                    = new ClientSocket(voters[Form1.index + 1],
                    Convert.ToInt32(votersPort[Form1.index + 1]),Form1.rtb);
                sender2.SendMessage(clientRSA.Encrypt("sendServ["), true);
                sender2.ClientClose();
            } else
            {
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\nСчетчик получил последний пакет с голосами";
                });
            }
        }

        public void Send()
        {
            RSA clientRSA = new RSA(
                    BigInteger.Parse(votersKey[num].Split('|')[0]),
                    BigInteger.Parse(votersKey[num].Split('|')[1]));
            ClientSocket sender
                = new ClientSocket(voters[num], Convert.ToInt32(votersPort[num]), Form1.rtb);
            sender.SendMessage(clientRSA.Encrypt(MVoite), true);
            sender.ClientClose();
        }

        public void sendVoite()
        {

            Console.Out.WriteLine("N:"+n+" MV:"+myVoters.Count);
            for (int i = 0; i < myVoters.Count; i++)
            {
                string MyVoite = "voite[" + counterRSA.Encrypt(myVoters[i]) + "[" + Form1.index;

                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\nИсходящий пакет " + "№" + (i+1)
                    +"\n"+voters[i % n]
                    + "\n" + votersPort[i % n]
                    + "\n" + myVoters[i];
                });

                Form1.canVoite = false;
                num = i % n;
                MVoite = MyVoite;
                Thread send = new Thread(delegate () { Send(); });
                send.IsBackground = true;
                send.Start();

                //int time = DateTime.Today.Millisecond;
                Form1.time = 0;
                while (!Form1.canVoite)
                {
                    if (Form1.time == 2)
                    {
                        Form1.time = 0;
                        Thread send2 = new Thread(delegate () { Send(); });
                        send2.IsBackground = true;
                        send2.Start();
                        rtb.Invoke((MethodInvoker)delegate ()
                        {
                            rtb.Text += "\n\nИсходящий пакет (повтор) " + "№" + (i+1)
                            + "\n" + voters[i % n]
                            + "\n" + votersPort[i % n]
                            + "\n" + myVoters[i];
                        });
                    }
                }

            }
            if (Form1.index+1 < n)
            {
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\nСледующий на очереди передавать голоса id: " + (Form1.index + 1);
                });
                RSA clientRSA = new RSA(
                   BigInteger.Parse(votersKey[Form1.index + 1].Split('|')[0]),
                   BigInteger.Parse(votersKey[Form1.index + 1].Split('|')[1]));
                ClientSocket sender
                    = new ClientSocket(voters[Form1.index + 1],
                    Convert.ToInt32(votersPort[Form1.index + 1]), Form1.rtb);
                sender.SendMessage(clientRSA.Encrypt("canVoite["), true);
                sender.ClientClose();

            }
            if (Form1.index+1 == n)
            {
                rtb.Invoke((MethodInvoker)delegate ()
                {
                    rtb.Text += "\n\nНачало передачи пакетов счетчику";
                });
                RSA clientRSA = new RSA(
                   BigInteger.Parse(votersKey[0].Split('|')[0]),
                   BigInteger.Parse(votersKey[0].Split('|')[1]));
                ClientSocket sender
                    = new ClientSocket(voters[0], Convert.ToInt32(votersPort[0]), Form1.rtb);
                sender.SendMessage(clientRSA.Encrypt("sendServ["), true);
                sender.ClientClose();
            }
        }

        public void Revoite()
        {

            voitesCount =  c = 0;
            voites = "";
            /* Thread send = new Thread(delegate () { sendVoite(); });
             send.IsBackground = true;
             send.Start();
             */
            sendVoite();
        }

        public void PleaseRevoite()
        {
            for (int i = 0; i < myVoters.Count; i++)
            {
                string MyVoite = "revoite["+ Form1.index;


                RSA clientRSA = new RSA(
                    BigInteger.Parse(votersKey[i % n].Split('|')[0]),
                    BigInteger.Parse(votersKey[i % n].Split('|')[1]));
                ClientSocket sender
                    = new ClientSocket(voters[i % n], Convert.ToInt32(votersPort[i % n]));
                sender.SendMessage(clientRSA.Encrypt(MyVoite), false);
                sender.ClientClose();

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
                    Console.Out.WriteLine("Listen...");
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
        public RSA myRSA = null;
        public RSA counterRSA = null;

        string[] voters = null;
        string[] votersPort = null;
        string[] votersKey = null;



        List<string> myVoters = new List<string>();

        public  volatile int myV = 0, n = 0, nk = 0;

        //string myVoite = "1|0|0|0";
        volatile string voites = "";
        volatile int voitesCount = 0;
        volatile int c = 0;

        string counterAddress = "";
        string counterK = "";
        string counterN = "";

        RichTextBox rtb;
        RichTextBox rtb2;

        Random rand = new Random();

        public SocketServer(string host, int port, RichTextBox rtb, RichTextBox rtb2)
        {

            this.rtb = rtb;
            this.rtb2 = rtb2;
            //this.voters = voters;
            ipHost = Dns.GetHostEntry(host);
            ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, port);

            // Create socket TCP/IP
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(100);

            // Create RSA key
            myRSA = new RSA();

            isListen = true;
        }
    }
}
