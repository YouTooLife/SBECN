using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CounterSBECN
{
    public partial class Form1 : Form
    {
        public SocketServer Server = null;
        public Thread ServThread = null;
        ClientSocket Client = null; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(textBox1.Text);
            comboBox1.Items.Clear();
            for (int i = 0; i < ipHost.AddressList.Count(); i++)
                comboBox1.Items.Add(ipHost.AddressList[i].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Server == null)
                {
                    Server = new SocketServer(textBox1.Text, comboBox1.SelectedIndex, 1013, richTextBox1);
                    ServThread = new Thread(delegate () { Server.ListenSocket(); });
                    ServThread.IsBackground = true;
                    ServThread.Start();
                }

                Client = new ClientSocket(textBox4.Text,
                     comboBox2.SelectedIndex,(int)numericUpDown1.Value);
                Client.SendMessage("counter["+ IPAddress.Parse(((IPEndPoint)Server.sListener.LocalEndPoint).Address.ToString())
                    +"["+Server.rsa.eps+"["+ Server.rsa.n, true);


                tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(textBox4.Text);
            comboBox2.Items.Clear();
            for (int i = 0; i < ipHost.AddressList.Count(); i++)
                comboBox2.Items.Add(ipHost.AddressList[i].ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Server.Revoite();
        }
    }
}
