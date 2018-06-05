namespace ClientSBECN
{
    public partial class Form1
    {

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 344);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.numericUpDown2);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(173, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Порт клиента:";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(384, 78);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = ">>";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(258, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(259, 200);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            1011,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(259, 133);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            1010,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(172, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Настройки подключения и сервера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Порт: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Адрес регистратора: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Подключится";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "127.0.0.1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.maskedTextBox2);
            this.tabPage2.Controls.Add(this.maskedTextBox1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(242, 224);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(137, 31);
            this.button7.TabIndex = 24;
            this.button7.Text = "Смотреть результаты";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(166, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Введите ФИО и паспортные данные";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "номер:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "серия:";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Паспорт: ";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "ФИО: ";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(331, 127);
            this.maskedTextBox2.Mask = "000000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2.TabIndex = 18;
            this.maskedTextBox2.Visible = false;
            this.maskedTextBox2.TextChanged += new System.EventHandler(this.maskedTextBox2_TextChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(242, 127);
            this.maskedTextBox1.Mask = "0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(43, 20);
            this.maskedTextBox1.TabIndex = 17;
            this.maskedTextBox1.Visible = false;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(242, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 32);
            this.button3.TabIndex = 16;
            this.button3.Text = "Голосовать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "< Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(209, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(222, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.checkedListBox1);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(616, 335);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(31, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(540, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "Выберите одного кандидата из списка, за которого Вы отдаете свой голос";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(211, 231);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 41);
            this.button5.TabIndex = 8;
            this.button5.Text = "Подтвердить голос";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(34, 70);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(280, 139);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 287);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "< Назад";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(320, 68);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(251, 141);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.richTextBox4);
            this.tabPage4.Controls.Add(this.richTextBox3);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(616, 335);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(530, 294);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 24);
            this.button6.TabIndex = 6;
            this.button6.Text = "Revote";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(275, 38);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(333, 245);
            this.richTextBox4.TabIndex = 5;
            this.richTextBox4.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(12, 38);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(257, 245);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(287, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Отчет о выборах:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(8, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Ваши пакеты голосов:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 300);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://vk.com/id__9800";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Coded by Egor Antonchikov";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button8);
            this.tabPage5.Controls.Add(this.richTextBox2);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Location = new System.Drawing.Point(4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(616, 335);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(229, 247);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 34);
            this.button8.TabIndex = 4;
            this.button8.Text = "Выход";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(105, 48);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(411, 182);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(101, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Результаты голосования:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(208, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(215, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Настройки подключения к регистратору:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(172, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Настройки локального сервера:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 344);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Client SBECN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.RichTextBox richTextBox3;
        public System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}

