using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSBECN
{

    public partial class Form1 : Form
    {

        public static List<string> person = new List<string>();
        public static List<string> person2 = new List<string>();

        SocketServer Server;
        Thread ServThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabControl1.TabIndex+1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                person.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            if (listBox1.Items.Count == 0)
            {
                button3.Enabled = false;
                panel2.Enabled = false;
            }
            if (listBox1.Items.Count > 1)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Участник "+ (listBox1.Items.Count+1));
            person.Add("Участник " + (listBox1.Items.Count)+"|..");
            if (listBox1.Items.Count > 1)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                button3.Enabled = true;
                panel2.Enabled = true;
                string s = person[listBox1.SelectedIndex];
                textBox1.Text = s.Split('|')[0]; 
                richTextBox1.Text = s.Split('|')[1];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            person[listBox1.SelectedIndex] = textBox1.Text + "|" + richTextBox1.Text;
            listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
            for (int i = 0; i < person.Count; i++)
            Console.Out.WriteLine(person[i]);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            person[listBox1.SelectedIndex] = textBox1.Text + "|" + richTextBox1.Text;
            Console.Out.WriteLine(person[listBox1.SelectedIndex]);
            for (int i = 0; i < person.Count; i++)
                Console.Out.WriteLine(person[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 1013)
            {
                MessageBox.Show("Порт 1013 может быть занят сервером счетчика!\nВыберите другой порт");
                return;
            }
            try
            {
                Server = new SocketServer(textBox2.Text, comboBox1.SelectedIndex,
                    (int)numericUpDown1.Value, richTextBox2);
                ServThread = new Thread(delegate () { Server.ListenSocket(); });
                ServThread.IsBackground = true;
                ServThread.Start();
                button5.Visible = false;
                button5.Enabled = false;
                tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Не удалось запиустить сервер :(\n\n"+ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button5.Visible = true;
            button5.Enabled = true;
            button1.Enabled = false;
            button1.Visible = false;
            tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            button5.Visible = false;
            button5.Enabled = false;
            button1.Enabled = true;
            button1.Visible = true;
            tabControl1.SelectTab(tabControl1.SelectedIndex-1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ServThread.Abort();
            Server.ServerClose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(textBox2.Text);
            comboBox1.Items.Clear();
            for (int i = 0; i < ipHost.AddressList.Count(); i++)
                comboBox1.Items.Add(ipHost.AddressList[i].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Out.WriteLine(comboBox1.SelectedIndex);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("Избиратель " + (listBox2.Items.Count + 1));
            person2.Add("Избиратель " + (listBox2.Items.Count));
            if (listBox2.Items.Count > 1)
                button8.Enabled = true;
            else
                button8.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                person2.RemoveAt(listBox2.SelectedIndex);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            if (listBox2.Items.Count == 0)
            {
                button3.Enabled = false;
                panel3.Enabled = false;
            }
            if (listBox2.Items.Count > 1)
                button1.Enabled = true;
            else
                button1.Enabled = false;

            if (listBox2.Items.Count > 1)
                button8.Enabled = true;
            else
                button8.Enabled = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                button8.Enabled = true;
                panel3.Enabled = true;
                string s = person2[listBox2.SelectedIndex];
                textBox3.Text = s;
            }
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count < 1)
            {
                MessageBox.Show("Добавьте избирателей!");
                return;
            }
            panel1.Visible = true;
            tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            person2[listBox2.SelectedIndex] = textBox3.Text;
            listBox2.Items[listBox2.SelectedIndex] = textBox3.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
    }
}
