namespace WinFormsApp1example_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            menuPanel = new Panel();
            componentTabBtn = new Button();
            GraphicsCardTabBtn = new Button();
            processorsTabBtn = new Button();
            ramTabBtn = new Button();
            componentManufactureText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            componentPriceText = new TextBox();
            label3 = new Label();
            componentSearchText = new TextBox();
            componentNameText = new TextBox();
            componentAddBtn = new Button();
            componentDeleteBtn = new Button();
            componentSearchBtn = new Button();
            pictureBox1 = new PictureBox();
            componentsPanel = new Panel();
            componentLoad = new Button();
            cmponentSave = new Button();
            graphicsCardPanel = new Panel();
            groupBoxGC = new GroupBox();
            label6 = new Label();
            label9 = new Label();
            graphicsCardBusWidthText = new TextBox();
            label8 = new Label();
            graphicsCardTypeText = new TextBox();
            label7 = new Label();
            graphicsCardMemorySizeText = new TextBox();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            graphicsCardDeletBtn = new Button();
            label5 = new Label();
            button9 = new Button();
            graphicsCardName = new TextBox();
            GCSearchText = new TextBox();
            graphicsCardPrice = new TextBox();
            graphicsCardManufacturer = new TextBox();
            dataGridView2 = new DataGridView();
            processorsPanel = new Panel();
            label17 = new Label();
            processorCoresText = new TextBox();
            label16 = new Label();
            processorFrequencyText = new TextBox();
            pictureBox4 = new PictureBox();
            label13 = new Label();
            processorDeleteBtn = new Button();
            label14 = new Label();
            label15 = new Label();
            processorAddBtn = new Button();
            processorNameText = new TextBox();
            processorSearchText = new TextBox();
            processorPriceText = new TextBox();
            processorManufacturerText = new TextBox();
            dataGridView4 = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Manufacturer = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Frequency = new DataGridViewTextBoxColumn();
            Cores = new DataGridViewTextBoxColumn();
            ramPanel = new Panel();
            groupBox12 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            checkBox1 = new CheckBox();
            label18 = new Label();
            textBox22 = new TextBox();
            pictureBox5 = new PictureBox();
            button16 = new Button();
            label20 = new Label();
            button17 = new Button();
            label21 = new Label();
            label22 = new Label();
            button18 = new Button();
            textBox24 = new TextBox();
            textBox25 = new TextBox();
            textBox26 = new TextBox();
            textBox27 = new TextBox();
            dataGridView5 = new DataGridView();
            extBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            componentsPanel.SuspendLayout();
            graphicsCardPanel.SuspendLayout();
            groupBoxGC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            processorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            ramPanel.SuspendLayout();
            groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Navy;
            dataGridViewCellStyle2.Font = new Font("Gilroy-Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new Font("Gilroy-Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.AliceBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(13, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(603, 171);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(componentTabBtn);
            menuPanel.Controls.Add(GraphicsCardTabBtn);
            menuPanel.Controls.Add(processorsTabBtn);
            menuPanel.Controls.Add(ramTabBtn);
            menuPanel.Location = new Point(1, 20);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(179, 264);
            menuPanel.TabIndex = 1;
            // 
            // componentTabBtn
            // 
            componentTabBtn.BackColor = Color.FromArgb(72, 134, 175);
            componentTabBtn.FlatStyle = FlatStyle.Flat;
            componentTabBtn.Location = new Point(7, 19);
            componentTabBtn.Name = "componentTabBtn";
            componentTabBtn.Size = new Size(161, 49);
            componentTabBtn.TabIndex = 0;
            componentTabBtn.Text = "Компоненты";
            componentTabBtn.UseVisualStyleBackColor = false;
            componentTabBtn.Click += componentTabBtn_Click;
            // 
            // GraphicsCardTabBtn
            // 
            GraphicsCardTabBtn.BackColor = Color.FromArgb(72, 134, 175);
            GraphicsCardTabBtn.FlatStyle = FlatStyle.Flat;
            GraphicsCardTabBtn.Location = new Point(7, 79);
            GraphicsCardTabBtn.Name = "GraphicsCardTabBtn";
            GraphicsCardTabBtn.Size = new Size(161, 49);
            GraphicsCardTabBtn.TabIndex = 1;
            GraphicsCardTabBtn.Text = "Видеокарты";
            GraphicsCardTabBtn.UseVisualStyleBackColor = false;
            GraphicsCardTabBtn.Click += GraphicsCardTabBtn_Click;
            // 
            // processorsTabBtn
            // 
            processorsTabBtn.BackColor = Color.FromArgb(72, 134, 175);
            processorsTabBtn.FlatStyle = FlatStyle.Flat;
            processorsTabBtn.Location = new Point(7, 138);
            processorsTabBtn.Name = "processorsTabBtn";
            processorsTabBtn.Size = new Size(161, 49);
            processorsTabBtn.TabIndex = 2;
            processorsTabBtn.Text = "Процессоры";
            processorsTabBtn.UseVisualStyleBackColor = false;
            processorsTabBtn.Click += processorsTabBtn_Click;
            // 
            // ramTabBtn
            // 
            ramTabBtn.BackColor = Color.FromArgb(72, 134, 175);
            ramTabBtn.FlatStyle = FlatStyle.Flat;
            ramTabBtn.Location = new Point(7, 202);
            ramTabBtn.Name = "ramTabBtn";
            ramTabBtn.Size = new Size(161, 49);
            ramTabBtn.TabIndex = 3;
            ramTabBtn.Text = "Оперативная память";
            ramTabBtn.UseVisualStyleBackColor = false;
            ramTabBtn.Click += ramTabBtn_Click;
            // 
            // componentManufactureText
            // 
            componentManufactureText.BackColor = Color.LightBlue;
            componentManufactureText.BorderStyle = BorderStyle.None;
            componentManufactureText.Location = new Point(151, 196);
            componentManufactureText.Multiline = true;
            componentManufactureText.Name = "componentManufactureText";
            componentManufactureText.Size = new Size(121, 34);
            componentManufactureText.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(13, 236);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(151, 236);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 5;
            label2.Text = "Производитель";
            // 
            // componentPriceText
            // 
            componentPriceText.BackColor = Color.LightBlue;
            componentPriceText.BorderStyle = BorderStyle.None;
            componentPriceText.Location = new Point(290, 196);
            componentPriceText.Multiline = true;
            componentPriceText.Name = "componentPriceText";
            componentPriceText.Size = new Size(121, 34);
            componentPriceText.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(290, 236);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 7;
            label3.Text = "Стоимость";
            // 
            // componentSearchText
            // 
            componentSearchText.BackColor = Color.LightBlue;
            componentSearchText.BorderStyle = BorderStyle.None;
            componentSearchText.Location = new Point(480, 196);
            componentSearchText.Multiline = true;
            componentSearchText.Name = "componentSearchText";
            componentSearchText.Size = new Size(121, 34);
            componentSearchText.TabIndex = 6;
            // 
            // componentNameText
            // 
            componentNameText.BackColor = Color.LightBlue;
            componentNameText.BorderStyle = BorderStyle.None;
            componentNameText.Location = new Point(13, 196);
            componentNameText.Multiline = true;
            componentNameText.Name = "componentNameText";
            componentNameText.Size = new Size(121, 34);
            componentNameText.TabIndex = 8;
            // 
            // componentAddBtn
            // 
            componentAddBtn.BackColor = Color.FromArgb(131, 193, 232);
            componentAddBtn.FlatAppearance.BorderSize = 0;
            componentAddBtn.FlatStyle = FlatStyle.Flat;
            componentAddBtn.ForeColor = Color.MidnightBlue;
            componentAddBtn.Location = new Point(13, 270);
            componentAddBtn.Name = "componentAddBtn";
            componentAddBtn.Size = new Size(121, 38);
            componentAddBtn.TabIndex = 3;
            componentAddBtn.Text = "Добавить";
            componentAddBtn.UseVisualStyleBackColor = false;
            componentAddBtn.Click += componentAddBtn_Click_1;
            // 
            // componentDeleteBtn
            // 
            componentDeleteBtn.BackColor = Color.FromArgb(131, 193, 232);
            componentDeleteBtn.FlatAppearance.BorderSize = 0;
            componentDeleteBtn.FlatStyle = FlatStyle.Flat;
            componentDeleteBtn.ForeColor = Color.MidnightBlue;
            componentDeleteBtn.Location = new Point(151, 270);
            componentDeleteBtn.Name = "componentDeleteBtn";
            componentDeleteBtn.Size = new Size(121, 38);
            componentDeleteBtn.TabIndex = 9;
            componentDeleteBtn.Text = "Удалить";
            componentDeleteBtn.UseVisualStyleBackColor = false;
            componentDeleteBtn.Click += componentDeleteBtn_Click;
            // 
            // componentSearchBtn
            // 
            componentSearchBtn.BackColor = Color.FromArgb(131, 193, 232);
            componentSearchBtn.FlatAppearance.BorderSize = 0;
            componentSearchBtn.FlatStyle = FlatStyle.Flat;
            componentSearchBtn.ForeColor = Color.MidnightBlue;
            componentSearchBtn.Location = new Point(26, 293);
            componentSearchBtn.Name = "componentSearchBtn";
            componentSearchBtn.Size = new Size(121, 38);
            componentSearchBtn.TabIndex = 10;
            componentSearchBtn.Text = "Поиск";
            componentSearchBtn.UseVisualStyleBackColor = false;
            componentSearchBtn.Click += componentSearchBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(441, 196);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // componentsPanel
            // 
            componentsPanel.Controls.Add(pictureBox1);
            componentsPanel.Controls.Add(componentNameText);
            componentsPanel.Controls.Add(label1);
            componentsPanel.Controls.Add(componentManufactureText);
            componentsPanel.Controls.Add(label2);
            componentsPanel.Controls.Add(componentPriceText);
            componentsPanel.Controls.Add(label3);
            componentsPanel.Controls.Add(componentDeleteBtn);
            componentsPanel.Controls.Add(componentAddBtn);
            componentsPanel.Controls.Add(componentSearchText);
            componentsPanel.Controls.Add(dataGridView1);
            componentsPanel.Location = new Point(197, 26);
            componentsPanel.Name = "componentsPanel";
            componentsPanel.Size = new Size(645, 393);
            componentsPanel.TabIndex = 13;
            // 
            // componentLoad
            // 
            componentLoad.BackColor = Color.FromArgb(131, 193, 232);
            componentLoad.FlatAppearance.BorderSize = 0;
            componentLoad.FlatStyle = FlatStyle.Flat;
            componentLoad.ForeColor = Color.MidnightBlue;
            componentLoad.Location = new Point(26, 387);
            componentLoad.Name = "componentLoad";
            componentLoad.Size = new Size(121, 38);
            componentLoad.TabIndex = 13;
            componentLoad.Text = "Загрузить";
            componentLoad.UseVisualStyleBackColor = false;
            componentLoad.Click += componentLoad_Click;
            // 
            // cmponentSave
            // 
            cmponentSave.BackColor = Color.FromArgb(131, 193, 232);
            cmponentSave.FlatAppearance.BorderSize = 0;
            cmponentSave.FlatStyle = FlatStyle.Flat;
            cmponentSave.ForeColor = Color.MidnightBlue;
            cmponentSave.Location = new Point(26, 339);
            cmponentSave.Name = "cmponentSave";
            cmponentSave.Size = new Size(121, 38);
            cmponentSave.TabIndex = 12;
            cmponentSave.Text = "Сохранить";
            cmponentSave.UseVisualStyleBackColor = false;
            cmponentSave.Click += cmponentSave_Click;
            // 
            // graphicsCardPanel
            // 
            graphicsCardPanel.Controls.Add(groupBoxGC);
            graphicsCardPanel.Controls.Add(dataGridView2);
            graphicsCardPanel.Location = new Point(189, 26);
            graphicsCardPanel.Name = "graphicsCardPanel";
            graphicsCardPanel.Size = new Size(650, 397);
            graphicsCardPanel.TabIndex = 14;
            graphicsCardPanel.Visible = false;
            // 
            // groupBoxGC
            // 
            groupBoxGC.Controls.Add(label6);
            groupBoxGC.Controls.Add(label9);
            groupBoxGC.Controls.Add(graphicsCardBusWidthText);
            groupBoxGC.Controls.Add(label8);
            groupBoxGC.Controls.Add(graphicsCardTypeText);
            groupBoxGC.Controls.Add(label7);
            groupBoxGC.Controls.Add(graphicsCardMemorySizeText);
            groupBoxGC.Controls.Add(pictureBox2);
            groupBoxGC.Controls.Add(label4);
            groupBoxGC.Controls.Add(graphicsCardDeletBtn);
            groupBoxGC.Controls.Add(label5);
            groupBoxGC.Controls.Add(button9);
            groupBoxGC.Controls.Add(graphicsCardName);
            groupBoxGC.Controls.Add(GCSearchText);
            groupBoxGC.Controls.Add(graphicsCardPrice);
            groupBoxGC.Controls.Add(graphicsCardManufacturer);
            groupBoxGC.Location = new Point(9, 186);
            groupBoxGC.Name = "groupBoxGC";
            groupBoxGC.Size = new Size(624, 193);
            groupBoxGC.TabIndex = 17;
            groupBoxGC.TabStop = false;
            groupBoxGC.Text = "groupBox1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(295, 57);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 7;
            label6.Text = "Стоимость";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(298, 121);
            label9.Name = "label9";
            label9.Size = new Size(112, 15);
            label9.TabIndex = 32;
            label9.Text = "Разрадность шины";
            // 
            // graphicsCardBusWidthText
            // 
            graphicsCardBusWidthText.BackColor = Color.LightBlue;
            graphicsCardBusWidthText.BorderStyle = BorderStyle.None;
            graphicsCardBusWidthText.Location = new Point(298, 81);
            graphicsCardBusWidthText.Multiline = true;
            graphicsCardBusWidthText.Name = "graphicsCardBusWidthText";
            graphicsCardBusWidthText.Size = new Size(121, 34);
            graphicsCardBusWidthText.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(159, 121);
            label8.Name = "label8";
            label8.Size = new Size(102, 15);
            label8.TabIndex = 30;
            label8.Text = "Тип видеопамяти";
            // 
            // graphicsCardTypeText
            // 
            graphicsCardTypeText.BackColor = Color.LightBlue;
            graphicsCardTypeText.BorderStyle = BorderStyle.None;
            graphicsCardTypeText.Location = new Point(159, 81);
            graphicsCardTypeText.Multiline = true;
            graphicsCardTypeText.Name = "graphicsCardTypeText";
            graphicsCardTypeText.Size = new Size(121, 34);
            graphicsCardTypeText.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 121);
            label7.Name = "label7";
            label7.Size = new Size(120, 15);
            label7.TabIndex = 28;
            label7.Text = "Объем видеопамяти";
            // 
            // graphicsCardMemorySizeText
            // 
            graphicsCardMemorySizeText.BackColor = Color.LightBlue;
            graphicsCardMemorySizeText.BorderStyle = BorderStyle.None;
            graphicsCardMemorySizeText.Location = new Point(18, 81);
            graphicsCardMemorySizeText.Multiline = true;
            graphicsCardMemorySizeText.Name = "graphicsCardMemorySizeText";
            graphicsCardMemorySizeText.Size = new Size(121, 34);
            graphicsCardMemorySizeText.TabIndex = 29;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(446, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 55);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 19;
            label4.Text = "Название";
            // 
            // graphicsCardDeletBtn
            // 
            graphicsCardDeletBtn.BackColor = Color.FromArgb(131, 193, 232);
            graphicsCardDeletBtn.FlatAppearance.BorderSize = 0;
            graphicsCardDeletBtn.FlatStyle = FlatStyle.Flat;
            graphicsCardDeletBtn.ForeColor = Color.MidnightBlue;
            graphicsCardDeletBtn.Location = new Point(156, 145);
            graphicsCardDeletBtn.Name = "graphicsCardDeletBtn";
            graphicsCardDeletBtn.Size = new Size(121, 38);
            graphicsCardDeletBtn.TabIndex = 25;
            graphicsCardDeletBtn.Text = "Удалить";
            graphicsCardDeletBtn.UseVisualStyleBackColor = false;
            graphicsCardDeletBtn.Click += graphicsCardDeletBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(156, 55);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 22;
            label5.Text = "Производитель";
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(131, 193, 232);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.ForeColor = Color.MidnightBlue;
            button9.Location = new Point(18, 145);
            button9.Name = "button9";
            button9.Size = new Size(121, 38);
            button9.TabIndex = 20;
            button9.Text = "Добавить";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // graphicsCardName
            // 
            graphicsCardName.BackColor = Color.LightBlue;
            graphicsCardName.BorderStyle = BorderStyle.None;
            graphicsCardName.Location = new Point(18, 17);
            graphicsCardName.Multiline = true;
            graphicsCardName.Name = "graphicsCardName";
            graphicsCardName.Size = new Size(120, 33);
            graphicsCardName.TabIndex = 24;
            // 
            // GCSearchText
            // 
            GCSearchText.BackColor = Color.LightBlue;
            GCSearchText.BorderStyle = BorderStyle.None;
            GCSearchText.Location = new Point(485, 9);
            GCSearchText.Multiline = true;
            GCSearchText.Name = "GCSearchText";
            GCSearchText.Size = new Size(121, 34);
            GCSearchText.TabIndex = 23;
            // 
            // graphicsCardPrice
            // 
            graphicsCardPrice.BackColor = Color.LightBlue;
            graphicsCardPrice.BorderStyle = BorderStyle.None;
            graphicsCardPrice.Location = new Point(295, 17);
            graphicsCardPrice.Multiline = true;
            graphicsCardPrice.Name = "graphicsCardPrice";
            graphicsCardPrice.Size = new Size(115, 33);
            graphicsCardPrice.TabIndex = 21;
            // 
            // graphicsCardManufacturer
            // 
            graphicsCardManufacturer.BackColor = Color.LightBlue;
            graphicsCardManufacturer.BorderStyle = BorderStyle.None;
            graphicsCardManufacturer.ForeColor = SystemColors.WindowText;
            graphicsCardManufacturer.Location = new Point(156, 17);
            graphicsCardManufacturer.Multiline = true;
            graphicsCardManufacturer.Name = "graphicsCardManufacturer";
            graphicsCardManufacturer.Size = new Size(124, 33);
            graphicsCardManufacturer.TabIndex = 18;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.Black;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(13, 9);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(603, 171);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellFormatting += dataGridView1_CellFormatting;
            // 
            // processorsPanel
            // 
            processorsPanel.Controls.Add(label17);
            processorsPanel.Controls.Add(processorCoresText);
            processorsPanel.Controls.Add(label16);
            processorsPanel.Controls.Add(processorFrequencyText);
            processorsPanel.Controls.Add(pictureBox4);
            processorsPanel.Controls.Add(label13);
            processorsPanel.Controls.Add(processorDeleteBtn);
            processorsPanel.Controls.Add(label14);
            processorsPanel.Controls.Add(label15);
            processorsPanel.Controls.Add(processorAddBtn);
            processorsPanel.Controls.Add(processorNameText);
            processorsPanel.Controls.Add(processorSearchText);
            processorsPanel.Controls.Add(processorPriceText);
            processorsPanel.Controls.Add(processorManufacturerText);
            processorsPanel.Controls.Add(dataGridView4);
            processorsPanel.Location = new Point(186, 29);
            processorsPanel.Name = "processorsPanel";
            processorsPanel.Size = new Size(656, 396);
            processorsPanel.TabIndex = 14;
            processorsPanel.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = SystemColors.ControlLight;
            label17.Location = new Point(151, 313);
            label17.Name = "label17";
            label17.Size = new Size(100, 15);
            label17.TabIndex = 14;
            label17.Text = "Количество ядер";
            // 
            // processorCoresText
            // 
            processorCoresText.BackColor = Color.FromArgb(131, 193, 232);
            processorCoresText.BorderStyle = BorderStyle.None;
            processorCoresText.Location = new Point(151, 273);
            processorCoresText.Multiline = true;
            processorCoresText.Name = "processorCoresText";
            processorCoresText.Size = new Size(121, 34);
            processorCoresText.TabIndex = 15;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = SystemColors.ControlLight;
            label16.Location = new Point(16, 314);
            label16.Name = "label16";
            label16.Size = new Size(71, 15);
            label16.TabIndex = 12;
            label16.Text = "Частота ЦП";
            // 
            // processorFrequencyText
            // 
            processorFrequencyText.BackColor = Color.FromArgb(131, 193, 232);
            processorFrequencyText.BorderStyle = BorderStyle.None;
            processorFrequencyText.Location = new Point(16, 274);
            processorFrequencyText.Multiline = true;
            processorFrequencyText.Name = "processorFrequencyText";
            processorFrequencyText.Size = new Size(121, 34);
            processorFrequencyText.TabIndex = 13;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(441, 196);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 34);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.ControlLight;
            label13.Location = new Point(13, 236);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 3;
            label13.Text = "Название";
            // 
            // processorDeleteBtn
            // 
            processorDeleteBtn.BackColor = Color.FromArgb(131, 193, 232);
            processorDeleteBtn.FlatAppearance.BorderSize = 0;
            processorDeleteBtn.FlatStyle = FlatStyle.Flat;
            processorDeleteBtn.ForeColor = Color.MidnightBlue;
            processorDeleteBtn.Location = new Point(151, 346);
            processorDeleteBtn.Name = "processorDeleteBtn";
            processorDeleteBtn.Size = new Size(121, 38);
            processorDeleteBtn.TabIndex = 9;
            processorDeleteBtn.Text = "Удалить";
            processorDeleteBtn.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = SystemColors.ControlLight;
            label14.Location = new Point(151, 236);
            label14.Name = "label14";
            label14.Size = new Size(92, 15);
            label14.TabIndex = 5;
            label14.Text = "Производитель";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = SystemColors.ControlLight;
            label15.Location = new Point(290, 236);
            label15.Name = "label15";
            label15.Size = new Size(67, 15);
            label15.TabIndex = 7;
            label15.Text = "Стоимость";
            // 
            // processorAddBtn
            // 
            processorAddBtn.BackColor = Color.FromArgb(131, 193, 232);
            processorAddBtn.FlatAppearance.BorderSize = 0;
            processorAddBtn.FlatStyle = FlatStyle.Flat;
            processorAddBtn.ForeColor = Color.MidnightBlue;
            processorAddBtn.Location = new Point(13, 346);
            processorAddBtn.Name = "processorAddBtn";
            processorAddBtn.Size = new Size(121, 38);
            processorAddBtn.TabIndex = 3;
            processorAddBtn.Text = "Добавить";
            processorAddBtn.UseVisualStyleBackColor = false;
            processorAddBtn.Click += processorAddBtn_Click;
            // 
            // processorNameText
            // 
            processorNameText.BackColor = Color.FromArgb(131, 193, 232);
            processorNameText.BorderStyle = BorderStyle.None;
            processorNameText.Location = new Point(13, 196);
            processorNameText.Multiline = true;
            processorNameText.Name = "processorNameText";
            processorNameText.Size = new Size(121, 34);
            processorNameText.TabIndex = 8;
            // 
            // processorSearchText
            // 
            processorSearchText.BackColor = Color.FromArgb(131, 193, 232);
            processorSearchText.BorderStyle = BorderStyle.None;
            processorSearchText.Location = new Point(480, 196);
            processorSearchText.Multiline = true;
            processorSearchText.Name = "processorSearchText";
            processorSearchText.Size = new Size(121, 34);
            processorSearchText.TabIndex = 6;
            // 
            // processorPriceText
            // 
            processorPriceText.BackColor = Color.FromArgb(131, 193, 232);
            processorPriceText.BorderStyle = BorderStyle.None;
            processorPriceText.Location = new Point(290, 196);
            processorPriceText.Multiline = true;
            processorPriceText.Name = "processorPriceText";
            processorPriceText.Size = new Size(121, 34);
            processorPriceText.TabIndex = 4;
            // 
            // processorManufacturerText
            // 
            processorManufacturerText.BackColor = Color.FromArgb(131, 193, 232);
            processorManufacturerText.BorderStyle = BorderStyle.None;
            processorManufacturerText.Location = new Point(151, 196);
            processorManufacturerText.Multiline = true;
            processorManufacturerText.Name = "processorManufacturerText";
            processorManufacturerText.Size = new Size(121, 34);
            processorManufacturerText.TabIndex = 2;
            // 
            // dataGridView4
            // 
            dataGridView4.BackgroundColor = SystemColors.ControlText;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Columns.AddRange(new DataGridViewColumn[] { Name, Manufacturer, Price, Frequency, Cores });
            dataGridView4.Location = new Point(13, 9);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(603, 171);
            dataGridView4.TabIndex = 0;
            dataGridView4.CellFormatting += dataGridView1_CellFormatting;
            // 
            // Name
            // 
            Name.HeaderText = "Название";
            Name.Name = "Name";
            // 
            // Manufacturer
            // 
            Manufacturer.HeaderText = "Производитель";
            Manufacturer.Name = "Manufacturer";
            // 
            // Price
            // 
            Price.HeaderText = "Стоимость";
            Price.Name = "Price";
            // 
            // Frequency
            // 
            Frequency.HeaderText = "Частота";
            Frequency.Name = "Frequency";
            // 
            // Cores
            // 
            Cores.HeaderText = "Количество ядер";
            Cores.Name = "Cores";
            // 
            // ramPanel
            // 
            ramPanel.Controls.Add(groupBox12);
            ramPanel.Controls.Add(dataGridView5);
            ramPanel.Location = new Point(192, 26);
            ramPanel.Name = "ramPanel";
            ramPanel.Size = new Size(647, 397);
            ramPanel.TabIndex = 16;
            ramPanel.Visible = false;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(button6);
            groupBox12.Controls.Add(button5);
            groupBox12.Controls.Add(checkBox1);
            groupBox12.Controls.Add(label18);
            groupBox12.Controls.Add(textBox22);
            groupBox12.Controls.Add(pictureBox5);
            groupBox12.Controls.Add(button16);
            groupBox12.Controls.Add(label20);
            groupBox12.Controls.Add(button17);
            groupBox12.Controls.Add(label21);
            groupBox12.Controls.Add(label22);
            groupBox12.Controls.Add(button18);
            groupBox12.Controls.Add(textBox24);
            groupBox12.Controls.Add(textBox25);
            groupBox12.Controls.Add(textBox26);
            groupBox12.Controls.Add(textBox27);
            groupBox12.Location = new Point(3, 186);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(645, 216);
            groupBox12.TabIndex = 17;
            groupBox12.TabStop = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(131, 193, 232);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(447, 154);
            button6.Name = "button6";
            button6.Size = new Size(121, 38);
            button6.TabIndex = 33;
            button6.Text = "Загрузить";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(131, 193, 232);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(298, 154);
            button5.Name = "button5";
            button5.Size = new Size(121, 38);
            button5.TabIndex = 32;
            button5.Text = "Сохранить";
            button5.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(13, 102);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(80, 19);
            checkBox1.TabIndex = 31;
            checkBox1.Text = "Комплект";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = SystemColors.ControlLightLight;
            label18.Location = new Point(148, 127);
            label18.Name = "label18";
            label18.Size = new Size(194, 15);
            label18.TabIndex = 29;
            label18.Text = "Количество модулей в комплекте";
            // 
            // textBox22
            // 
            textBox22.BackColor = Color.LightBlue;
            textBox22.BorderStyle = BorderStyle.None;
            textBox22.Location = new Point(151, 87);
            textBox22.Multiline = true;
            textBox22.Name = "textBox22";
            textBox22.Size = new Size(121, 34);
            textBox22.TabIndex = 30;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(447, 22);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(42, 34);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 26;
            pictureBox5.TabStop = false;
            // 
            // button16
            // 
            button16.BackColor = Color.FromArgb(131, 193, 232);
            button16.FlatAppearance.BorderSize = 0;
            button16.FlatStyle = FlatStyle.Flat;
            button16.ForeColor = SystemColors.ControlText;
            button16.Location = new Point(447, 84);
            button16.Name = "button16";
            button16.Size = new Size(121, 38);
            button16.TabIndex = 25;
            button16.Text = "Поиск";
            button16.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = SystemColors.ControlLightLight;
            label20.Location = new Point(13, 62);
            label20.Name = "label20";
            label20.Size = new Size(59, 15);
            label20.TabIndex = 17;
            label20.Text = "Название";
            // 
            // button17
            // 
            button17.BackColor = Color.FromArgb(131, 193, 232);
            button17.FlatAppearance.BorderSize = 0;
            button17.FlatStyle = FlatStyle.Flat;
            button17.ForeColor = SystemColors.ControlText;
            button17.Location = new Point(151, 154);
            button17.Name = "button17";
            button17.Size = new Size(121, 38);
            button17.TabIndex = 24;
            button17.Text = "Удалить";
            button17.UseVisualStyleBackColor = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ForeColor = SystemColors.ControlLightLight;
            label21.Location = new Point(151, 62);
            label21.Name = "label21";
            label21.Size = new Size(92, 15);
            label21.TabIndex = 20;
            label21.Text = "Производитель";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = SystemColors.ControlLightLight;
            label22.Location = new Point(290, 62);
            label22.Name = "label22";
            label22.Size = new Size(67, 15);
            label22.TabIndex = 22;
            label22.Text = "Стоимость";
            // 
            // button18
            // 
            button18.BackColor = Color.FromArgb(131, 193, 232);
            button18.FlatAppearance.BorderSize = 0;
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = SystemColors.ControlText;
            button18.Location = new Point(13, 154);
            button18.Name = "button18";
            button18.Size = new Size(121, 38);
            button18.TabIndex = 18;
            button18.Text = "Добавить";
            button18.UseVisualStyleBackColor = false;
            // 
            // textBox24
            // 
            textBox24.BackColor = Color.LightBlue;
            textBox24.BorderStyle = BorderStyle.None;
            textBox24.Location = new Point(13, 22);
            textBox24.Multiline = true;
            textBox24.Name = "textBox24";
            textBox24.Size = new Size(121, 34);
            textBox24.TabIndex = 23;
            // 
            // textBox25
            // 
            textBox25.BackColor = Color.LightBlue;
            textBox25.BorderStyle = BorderStyle.None;
            textBox25.Location = new Point(486, 22);
            textBox25.Multiline = true;
            textBox25.Name = "textBox25";
            textBox25.Size = new Size(121, 34);
            textBox25.TabIndex = 21;
            // 
            // textBox26
            // 
            textBox26.BackColor = Color.LightBlue;
            textBox26.BorderStyle = BorderStyle.None;
            textBox26.Location = new Point(290, 22);
            textBox26.Multiline = true;
            textBox26.Name = "textBox26";
            textBox26.Size = new Size(121, 34);
            textBox26.TabIndex = 19;
            // 
            // textBox27
            // 
            textBox27.BackColor = Color.LightBlue;
            textBox27.BorderStyle = BorderStyle.None;
            textBox27.Location = new Point(151, 22);
            textBox27.Multiline = true;
            textBox27.Name = "textBox27";
            textBox27.Size = new Size(121, 34);
            textBox27.TabIndex = 16;
            // 
            // dataGridView5
            // 
            dataGridView5.BackgroundColor = Color.Black;
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(13, 9);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.Size = new Size(603, 171);
            dataGridView5.TabIndex = 0;
            dataGridView5.CellFormatting += dataGridView1_CellFormatting;
            // 
            // extBtn
            // 
            extBtn.BackColor = Color.FromArgb(7, 50, 69);
            extBtn.BackgroundImage = (Image)resources.GetObject("extBtn.BackgroundImage");
            extBtn.BackgroundImageLayout = ImageLayout.Center;
            extBtn.FlatAppearance.BorderSize = 0;
            extBtn.FlatStyle = FlatStyle.Flat;
            extBtn.ForeColor = SystemColors.ControlLightLight;
            extBtn.Location = new Point(831, 2);
            extBtn.Name = "extBtn";
            extBtn.Size = new Size(46, 29);
            extBtn.TabIndex = 17;
            extBtn.UseVisualStyleBackColor = false;
            extBtn.Click += extBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(7, 50, 69);
            ClientSize = new Size(878, 450);
            Controls.Add(extBtn);
            Controls.Add(componentSearchBtn);
            Controls.Add(cmponentSave);
            Controls.Add(processorsPanel);
            Controls.Add(componentLoad);
            Controls.Add(ramPanel);
            Controls.Add(graphicsCardPanel);
            Controls.Add(componentsPanel);
            Controls.Add(menuPanel);
            FormBorderStyle = FormBorderStyle.None; 
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            componentsPanel.ResumeLayout(false);
            componentsPanel.PerformLayout();
            graphicsCardPanel.ResumeLayout(false);
            groupBoxGC.ResumeLayout(false);
            groupBoxGC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            processorsPanel.ResumeLayout(false);
            processorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ramPanel.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel menuPanel;
        private Button processorsTabBtn;
        private Button GraphicsCardTabBtn;
        private Button componentTabBtn;
        private TextBox componentManufactureText;
        private Label label1;
        private Label label2;
        private TextBox componentPriceText;
        private Label label3;
        private TextBox componentSearchText;
        private TextBox componentNameText;
        private Button componentAddBtn;
        private Button componentDeleteBtn;
        private Button componentSearchBtn;
        private PictureBox pictureBox1;
        private Panel componentsPanel;
        private Button ramTabBtn;
        private Panel graphicsCardPanel;
        private Label label6;
        private DataGridView dataGridView2;
        private Panel processorsPanel;
        private PictureBox pictureBox4;
        private Label label13;
        private Button processorDeleteBtn;
        private Label label14;
        private Label label15;
        private Button processorAddBtn;
        private TextBox processorNameText;
        private TextBox processorSearchText;
        private TextBox processorPriceText;
        private TextBox processorManufacturerText;
        private DataGridView dataGridView4;
        private Label label17;
        private TextBox processorCoresText;
        private Label label16;
        private TextBox processorFrequencyText;
        private Panel ramPanel;
        private DataGridView dataGridView5;
        private GroupBox groupBox12;
        private Label label18;
        private TextBox textBox22;
        private PictureBox pictureBox5;
        private Button button16;
        private Label label20;
        private Button button17;
        private Label label21;
        private Label label22;
        private Button button18;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private CheckBox checkBox1;
        private GroupBox groupBoxGC;
        private Label label9;
        private TextBox graphicsCardBusWidthText;
        private Label label8;
        private TextBox graphicsCardTypeText;
        private Label label7;
        private TextBox graphicsCardMemorySizeText;
        private PictureBox pictureBox2;
        private Label label4;
        private Button graphicsCardDeletBtn;
        private Label label5;
        private Button button9;
        private TextBox graphicsCardName;
        private TextBox GCSearchText;
        private TextBox graphicsCardPrice;
        private TextBox graphicsCardManufacturer;
        private Button extBtn;
        private Button componentLoad;
        private Button cmponentSave;
        private Button button6;
        private Button button5;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Manufacturer;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Frequency;
        private DataGridViewTextBoxColumn Cores;
    }
}
