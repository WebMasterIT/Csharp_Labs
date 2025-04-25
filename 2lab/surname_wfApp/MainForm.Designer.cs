namespace surname_wfApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.HotTrack, null);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.HotTrack, null);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.HotTrack, null);
            button4 = new Button();
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            pnlnav = new Panel();
            checkBoxDarkMode = new CheckBox();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button5 = new Button();
            listView1 = new ListView();
            Название = new ColumnHeader();
            Производитель = new ColumnHeader();
            Стоимость = new ColumnHeader();
            panel3 = new Panel();
            button7 = new Button();
            SearchButton = new Button();
            pictureBox2 = new PictureBox();
            textBoxSearch = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxPrice = new TextBox();
            textBoxManufacture = new TextBox();
            textBoxName = new TextBox();
            button6 = new Button();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            panel4 = new Panel();
            label8 = new Label();
            label9 = new Label();
            textBoxGCManufacture = new TextBox();
            textBoxGCPrice = new TextBox();
            textBoxGCName = new TextBox();
            dataGridView1 = new DataGridView();
            button8 = new Button();
            button9 = new Button();
            pictureBox3 = new PictureBox();
            textBoxGCSearch = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxGCType = new TextBox();
            textBoxGCcores = new TextBox();
            textBoxVolume = new TextBox();
            button10 = new Button();
            menuStrip2 = new MenuStrip();
            файлToolStripMenuItem1 = new ToolStripMenuItem();
            сохранитьToolStripMenuItem1 = new ToolStripMenuItem();
            загрузитьToolStripMenuItem1 = new ToolStripMenuItem();
            panel5 = new Panel();
            listView3 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            dataGridView2 = new DataGridView();
            panel6 = new Panel();
            listView4 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            dataGridView3 = new DataGridView();
            fileSystemWatcher1 = new FileSystemWatcher();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menuStrip2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(1, 35, 76);
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Gilroy-Regular", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.LightSteelBlue;
            button4.Location = new Point(0, 304);
            button4.Name = "button4";
            button4.Size = new Size(245, 58);
            button4.TabIndex = 8;
            button4.Text = "Оперативная память";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            button4.Leave += button4_Leave_1;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(1, 35, 76);
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Gilroy-Regular", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.LightSteelBlue;
            button2.Location = new Point(0, 190);
            button2.Name = "button2";
            button2.Size = new Size(245, 57);
            button2.TabIndex = 7;
            button2.Text = "Видеокарты";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.Leave += button2_Leave_1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(1, 35, 76);
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Gilroy-Regular", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.LightSteelBlue;
            button3.Location = new Point(0, 247);
            button3.Name = "button3";
            button3.Size = new Size(245, 57);
            button3.TabIndex = 6;
            button3.Text = "Процессоры";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.Leave += button3_Leave_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(1, 35, 76);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Gilroy-Regular", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.LightSteelBlue;
            button1.Location = new Point(0, 137);
            button1.Name = "button1";
            button1.Size = new Size(245, 53);
            button1.TabIndex = 5;
            button1.Text = "Компоненты";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            button1.Leave += button1_Leave;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 35, 76);
            panel1.Controls.Add(pnlnav);
            panel1.Controls.Add(checkBoxDarkMode);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = Color.Yellow;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 680);
            panel1.TabIndex = 10;
            // 
            // pnlnav
            // 
            pnlnav.BackColor = SystemColors.ActiveCaption;
            pnlnav.Location = new Point(2, 220);
            pnlnav.Name = "pnlnav";
            pnlnav.Size = new Size(3, 140);
            pnlnav.TabIndex = 13;
            // 
            // checkBoxDarkMode
            // 
            checkBoxDarkMode.AutoSize = true;
            checkBoxDarkMode.Location = new Point(12, 376);
            checkBoxDarkMode.Name = "checkBoxDarkMode";
            checkBoxDarkMode.Size = new Size(81, 19);
            checkBoxDarkMode.TabIndex = 25;
            checkBoxDarkMode.Text = "DarkMode";
            checkBoxDarkMode.UseVisualStyleBackColor = true;
            checkBoxDarkMode.CheckedChanged += checkBoxDarkMode_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = Color.DarkOliveGreen;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 137);
            panel2.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gilroy-Regular", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Wheat;
            label1.Location = new Point(83, 95);
            label1.Name = "label1";
            label1.Size = new Size(71, 14);
            label1.TabIndex = 11;
            label1.Text = "Kondakov_v";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Center;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(1137, 0);
            button5.Name = "button5";
            button5.Size = new Size(36, 30);
            button5.TabIndex = 13;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Название, Производитель, Стоимость });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView1.Location = new Point(15, 62);
            listView1.Name = "listView1";
            listView1.Size = new Size(871, 258);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Название
            // 
            Название.Text = "Название";
            Название.Width = 400;
            // 
            // Производитель
            // 
            Производитель.Text = "Производитель";
            Производитель.Width = 300;
            // 
            // Стоимость
            // 
            Стоимость.Text = "Стоимость";
            Стоимость.Width = 100;
            // 
            // panel3
            // 
            panel3.Controls.Add(button7);
            panel3.Controls.Add(SearchButton);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(textBoxSearch);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBoxPrice);
            panel3.Controls.Add(textBoxManufacture);
            panel3.Controls.Add(textBoxName);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(listView1);
            panel3.Controls.Add(menuStrip1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(-2534, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(926, 680);
            panel3.TabIndex = 14;
            // 
            // button7
            // 
            button7.BackColor = Color.MidnightBlue;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(183, 422);
            button7.Name = "button7";
            button7.Size = new Size(116, 45);
            button7.TabIndex = 23;
            button7.Text = "Удалить";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.MidnightBlue;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = SystemColors.ButtonFace;
            SearchButton.Location = new Point(594, 422);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(106, 50);
            SearchButton.TabIndex = 22;
            SearchButton.Text = "Найти";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.icons8_search_501;
            pictureBox2.Location = new Point(594, 363);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.None;
            textBoxSearch.Font = new Font("Gilroy-Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSearch.Location = new Point(626, 363);
            textBoxSearch.Multiline = true;
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Какой угодно текст";
            textBoxSearch.Size = new Size(158, 32);
            textBoxSearch.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(354, 334);
            label4.Name = "label4";
            label4.Size = new Size(91, 19);
            label4.TabIndex = 19;
            label4.Text = "Стоимость";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(183, 334);
            label3.Name = "label3";
            label3.Size = new Size(125, 19);
            label3.TabIndex = 18;
            label3.Text = "Производитель";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(14, 334);
            label2.Name = "label2";
            label2.Size = new Size(82, 19);
            label2.TabIndex = 17;
            label2.Text = "Название";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(354, 365);
            textBoxPrice.Multiline = true;
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(141, 30);
            textBoxPrice.TabIndex = 16;
            // 
            // textBoxManufacture
            // 
            textBoxManufacture.Location = new Point(183, 365);
            textBoxManufacture.Multiline = true;
            textBoxManufacture.Name = "textBoxManufacture";
            textBoxManufacture.Size = new Size(141, 30);
            textBoxManufacture.TabIndex = 15;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(15, 365);
            textBoxName.Multiline = true;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(141, 30);
            textBoxName.TabIndex = 14;
            // 
            // button6
            // 
            button6.BackColor = Color.MidnightBlue;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            button6.FlatAppearance.MouseOverBackColor = SystemColors.InfoText;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.ButtonHighlight;
            button6.Location = new Point(15, 422);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Size = new Size(141, 45);
            button6.TabIndex = 13;
            button6.Text = "Добавить компонент";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(926, 24);
            menuStrip1.TabIndex = 24;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, загрузитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(133, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(133, 22);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            загрузитьToolStripMenuItem.Click += загрузитьToolStripMenuItem_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(textBoxGCManufacture);
            panel4.Controls.Add(textBoxGCPrice);
            panel4.Controls.Add(textBoxGCName);
            panel4.Controls.Add(dataGridView1);
            panel4.Controls.Add(button8);
            panel4.Controls.Add(button9);
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(textBoxGCSearch);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(textBoxGCType);
            panel4.Controls.Add(textBoxGCcores);
            panel4.Controls.Add(textBoxVolume);
            panel4.Controls.Add(button10);
            panel4.Controls.Add(menuStrip2);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(244, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(927, 680);
            panel4.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(360, 313);
            label8.Name = "label8";
            label8.Size = new Size(91, 19);
            label8.TabIndex = 42;
            label8.Text = "Стоимость";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(190, 313);
            label9.Name = "label9";
            label9.Size = new Size(137, 19);
            label9.TabIndex = 41;
            label9.Text = "Тип видеопамяти";
            // 
            // textBoxGCManufacture
            // 
            textBoxGCManufacture.Location = new Point(190, 344);
            textBoxGCManufacture.Multiline = true;
            textBoxGCManufacture.Name = "textBoxGCManufacture";
            textBoxGCManufacture.Size = new Size(141, 30);
            textBoxGCManufacture.TabIndex = 38;
            // 
            // textBoxGCPrice
            // 
            textBoxGCPrice.Location = new Point(360, 342);
            textBoxGCPrice.Multiline = true;
            textBoxGCPrice.Name = "textBoxGCPrice";
            textBoxGCPrice.Size = new Size(141, 30);
            textBoxGCPrice.TabIndex = 39;
            // 
            // textBoxGCName
            // 
            textBoxGCName.Location = new Point(16, 330);
            textBoxGCName.Multiline = true;
            textBoxGCName.Name = "textBoxGCName";
            textBoxGCName.PlaceholderText = "Название видеокарты";
            textBoxGCName.Size = new Size(141, 30);
            textBoxGCName.TabIndex = 37;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(868, 237);
            dataGridView1.TabIndex = 35;
            // 
            // button8
            // 
            button8.BackColor = Color.MidnightBlue;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(190, 494);
            button8.Name = "button8";
            button8.Size = new Size(116, 45);
            button8.TabIndex = 34;
            button8.Text = "Удалить";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.MidnightBlue;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.ForeColor = SystemColors.ButtonFace;
            button9.Location = new Point(600, 491);
            button9.Name = "button9";
            button9.Size = new Size(106, 50);
            button9.TabIndex = 33;
            button9.Text = "Найти";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = Properties.Resources.icons8_search_501;
            pictureBox3.Location = new Point(600, 437);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 32;
            pictureBox3.TabStop = false;
            // 
            // textBoxGCSearch
            // 
            textBoxGCSearch.BorderStyle = BorderStyle.None;
            textBoxGCSearch.Font = new Font("Gilroy-Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxGCSearch.Location = new Point(632, 437);
            textBoxGCSearch.Multiline = true;
            textBoxGCSearch.Name = "textBoxGCSearch";
            textBoxGCSearch.PlaceholderText = "Поиск...";
            textBoxGCSearch.Size = new Size(158, 30);
            textBoxGCSearch.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(360, 405);
            label5.Name = "label5";
            label5.Size = new Size(136, 19);
            label5.TabIndex = 30;
            label5.Text = "Количество ядер";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(186, 405);
            label6.Name = "label6";
            label6.Size = new Size(137, 19);
            label6.TabIndex = 29;
            label6.Text = "Тип видеопамяти";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Gilroy-Regular", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(13, 406);
            label7.Name = "label7";
            label7.Size = new Size(161, 19);
            label7.TabIndex = 28;
            label7.Text = "Объём видеопамяти";
            // 
            // textBoxGCType
            // 
            textBoxGCType.Location = new Point(190, 437);
            textBoxGCType.Multiline = true;
            textBoxGCType.Name = "textBoxGCType";
            textBoxGCType.Size = new Size(141, 30);
            textBoxGCType.TabIndex = 26;
            // 
            // textBoxGCcores
            // 
            textBoxGCcores.Location = new Point(360, 437);
            textBoxGCcores.Multiline = true;
            textBoxGCcores.Name = "textBoxGCcores";
            textBoxGCcores.Size = new Size(141, 30);
            textBoxGCcores.TabIndex = 27;
            // 
            // textBoxVolume
            // 
            textBoxVolume.Location = new Point(17, 437);
            textBoxVolume.Multiline = true;
            textBoxVolume.Name = "textBoxVolume";
            textBoxVolume.Size = new Size(141, 30);
            textBoxVolume.TabIndex = 25;
            // 
            // button10
            // 
            button10.BackColor = Color.MidnightBlue;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            button10.FlatAppearance.MouseOverBackColor = SystemColors.InfoText;
            button10.FlatStyle = FlatStyle.Flat;
            button10.ForeColor = SystemColors.ButtonHighlight;
            button10.Location = new Point(17, 494);
            button10.Margin = new Padding(0);
            button10.Name = "button10";
            button10.Size = new Size(141, 45);
            button10.TabIndex = 24;
            button10.Text = "Добавить компонент";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem1 });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(927, 24);
            menuStrip2.TabIndex = 36;
            menuStrip2.Text = "menuStrip2";
            // 
            // файлToolStripMenuItem1
            // 
            файлToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem1, загрузитьToolStripMenuItem1 });
            файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            файлToolStripMenuItem1.Size = new Size(48, 20);
            файлToolStripMenuItem1.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem1
            // 
            сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            сохранитьToolStripMenuItem1.Size = new Size(133, 22);
            сохранитьToolStripMenuItem1.Text = "Сохранить";
            сохранитьToolStripMenuItem1.Click += сохранитьToolStripMenuItem1_Click;
            // 
            // загрузитьToolStripMenuItem1
            // 
            загрузитьToolStripMenuItem1.Name = "загрузитьToolStripMenuItem1";
            загрузитьToolStripMenuItem1.Size = new Size(133, 22);
            загрузитьToolStripMenuItem1.Text = "Загрузить";
            загрузитьToolStripMenuItem1.Click += загрузитьToolStripMenuItem1_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(listView3);
            panel5.Controls.Add(dataGridView2);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(-682, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(926, 680);
            panel5.TabIndex = 15;
            panel5.Visible = false;
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            listView3.Items.AddRange(new ListViewItem[] { listViewItem2 });
            listView3.Location = new Point(38, 201);
            listView3.Name = "listView3";
            listView3.Size = new Size(568, 147);
            listView3.TabIndex = 12;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "вцвфцв";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(38, 74);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(396, 86);
            dataGridView2.TabIndex = 11;
            // 
            // panel6
            // 
            panel6.Controls.Add(listView4);
            panel6.Controls.Add(dataGridView3);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(-1608, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(926, 680);
            panel6.TabIndex = 15;
            panel6.Visible = false;
            // 
            // listView4
            // 
            listView4.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8 });
            listView4.Items.AddRange(new ListViewItem[] { listViewItem3 });
            listView4.Location = new Point(38, 257);
            listView4.Name = "listView4";
            listView4.Size = new Size(568, 147);
            listView4.TabIndex = 12;
            listView4.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "вцвфцв";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(38, 90);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(396, 86);
            dataGridView3.TabIndex = 11;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(94, 131, 186);
            ClientSize = new Size(1171, 680);
            Controls.Add(button5);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button4;
        private Button button2;
        private Button button3;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private ListView listView1;
        private ColumnHeader Название;
        private ColumnHeader Производитель;
        private Button button5;
        private Panel pnlnav;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private ListView listView3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private DataGridView dataGridView2;
        private Panel panel6;
        private ListView listView4;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private DataGridView dataGridView3;
        private Label label3;
        private Label label2;
        private TextBox textBoxPrice;
        private TextBox textBoxManufacture;
        private TextBox textBoxName;
        private Label label4;
        private ColumnHeader Стоимость;
        private TextBox textBoxSearch;
        private PictureBox pictureBox2;
        private Button SearchButton;
        private Button button6;
        private Button button7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem загрузитьToolStripMenuItem;
        private DataGridView dataGridView1;
        private Button button8;
        private Button button9;
        private PictureBox pictureBox3;
        private TextBox textBoxGCSearch;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxGCcores;
        private TextBox textBoxGCType;
        private TextBox textBoxVolume;
        private Button button10;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem файлToolStripMenuItem1;
        private ToolStripMenuItem сохранитьToolStripMenuItem1;
        private ToolStripMenuItem загрузитьToolStripMenuItem1;
        private Label label8;
        private Label label9;
        private TextBox textBoxGCManufacture;
        private TextBox textBoxGCPrice;
        private TextBox textBoxGCName;
        private CheckBox checkBoxDarkMode;
        private FileSystemWatcher fileSystemWatcher1;
    }
}