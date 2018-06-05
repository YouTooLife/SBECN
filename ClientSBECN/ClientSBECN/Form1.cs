using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSBECN
{
    public partial class Form1 : Form
    {
        public static SocketServer Server = null;
        public static int index = 0;
        public static RichTextBox rtb = null;
        public static int time = 0;

        public static bool canVoite = true;

        ClientSocket Client = null;

        public Thread ServThread = null;
        
        int voite = 0;
        public Form1()
        {
            InitializeComponent();
            rtb = richTextBox3;
        }



        

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 1013)
            {
                MessageBox.Show("Порт 1013 может быть занят сервером счетчика!\nВыберите другой порт");
                return;
            }
            try
            {
                if (Server == null)
                {
                    Server = new SocketServer("127.0.0.1", (int)numericUpDown2.Value,
                        richTextBox3, richTextBox4);
                    ServThread = new Thread(delegate () { Server.ListenSocket(); });
                    ServThread.IsBackground = true;
                    ServThread.Start();
                }

                Client = new ClientSocket(textBox1.Text, comboBox1.SelectedIndex,
                     (int)numericUpDown1.Value, richTextBox1, checkedListBox1);

                tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.ClientClose();
            tabControl1.SelectTab(tabControl1.SelectedIndex-1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabControl1.SelectedIndex - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (voite < 0)
            {
                MessageBox.Show("Выберите кандидата!");
                return;
            }
            Server.myV = checkedListBox1.SelectedIndex;
            Server.nk = checkedListBox1.Items.Count;
            string message = "voite[" + textBox3.Text + "["
                + IPAddress.Parse(((IPEndPoint)Server.sListener.LocalEndPoint).Address.ToString()) + "[" 
                + (int)numericUpDown2.Value + "[" + Server.myRSA.eps + "|" + Server.myRSA.n;
            tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
            Client.SendMessage(message);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != checkedListBox1.SelectedIndex)
                    checkedListBox1.SetItemChecked(i, false);
            }
            if (checkedListBox1.SelectedIndex > -1)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
                voite = checkedListBox1.SelectedIndex;
                button5.Enabled = true;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Client != null)
                Client.ClientClose();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 1) 
               // maskedTextBox1.Text.Length < 1 ||
               // maskedTextBox2.Text.Length < 1)
            {
                button7.Enabled = false;
                button3.Enabled = false;
            } else
            {
                button7.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 1 ||
                maskedTextBox1.Text.Length < 4 ||
                maskedTextBox2.Text.Length < 6)
            {
                button7.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 1 ||
                maskedTextBox1.Text.Length < 4 ||
                maskedTextBox2.Text.Length < 6)
            {
                button7.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message = "getResult[" + maskedTextBox1.Text + maskedTextBox2.Text + "[" + textBox3 + "[" + voite;
            tabControl1.SelectTab(tabControl1.TabPages.Count-1);
            Client.SendMessage(message);
            richTextBox2.Text = Client.result;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(textBox1.Text);
            comboBox1.Items.Clear();
            for (int i = 0; i < ipHost.AddressList.Count(); i++)
                comboBox1.Items.Add(ipHost.AddressList[i].ToString());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Server.PleaseRevoite();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time < 2)
                time++;
        }
    }
}
