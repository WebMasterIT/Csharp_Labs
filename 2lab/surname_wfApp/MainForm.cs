using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization; 
using surname_wfApp.Models;
using System.Xml.Linq;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace surname_wfApp
{
    public partial class MainForm : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse

       );


        private void ShowPanel(Panel panel)
        {
            // Скрываем все панели
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            // Показываем нужную панель
            panel.Visible = true;
        }


        //коллекция для хранения элементов listView
        private List<ListViewItem> originalItems = new List<ListViewItem>();


        private List<Component> componentsList = new List<Component>();

        public MainForm()
        {
            InitializeComponent();

            // Подключаем обработчики событий к форме
            this.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            this.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            this.MouseUp += new MouseEventHandler(MainForm_MouseUp);


            Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 25, 25)
            );
            pnlnav.Height = button1.Height;
            pnlnav.Top = button1.Top;
            pnlnav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

            listView1.View = View.Details;


            // Предположим, что listView1 уже содержит некоторые элементы
            // Сохраняем их в оригинальный список
            foreach (ListViewItem item in listView1.Items)
            {
                originalItems.Add((ListViewItem)item.Clone());
            }

            // Подписываемся на событие Click кнопки
            SearchButton.Click += SearchButton_Click;


            // Настройка DataGridView (если не задана через дизайнер)
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }



        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point newPosition = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            pnlnav.Height = button1.Height;
            pnlnav.Top = button1.Top;
            pnlnav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

            ShowPanel(panel3);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlnav.Height = button2.Height;
            pnlnav.Top = button2.Top;
            pnlnav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);

            ShowPanel(panel4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlnav.Height = button3.Height;
            pnlnav.Top = button3.Top;
            pnlnav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(46, 51, 73);

            ShowPanel(panel5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlnav.Height = button4.Height;
            pnlnav.Top = button4.Top;
            pnlnav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);

            ShowPanel(panel6);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                                         "Подтверждение",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }





        private void button2_Leave_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(1, 35, 76);
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(1, 35, 76);
        }

        private void button3_Leave_1(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(1, 35, 76);
        }

        private void button4_Leave_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(1, 35, 76);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
           string.IsNullOrWhiteSpace(textBoxManufacture.Text) ||
           string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price < 1m || price > 100000000m)
            {
                MessageBox.Show("Введите корректное значение цены (число от 1 до 100000000).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            // Создаем строку для добавления в ListView
            string[] row = { textBoxName.Text, textBoxManufacture.Text, textBoxPrice.Text };
            ListViewItem item = new ListViewItem(row);

            // Добавляем элемент в ListView
            listView1.Items.Add(item);

            // Также добавляем копию в originalItems для последующей фильтрации
            originalItems.Add((ListViewItem)item.Clone());


            Component newComponent = new Component(textBoxName.Text, textBoxManufacture.Text, price);
            componentsList.Add(newComponent);
            UpdateListView(componentsList);
            textBoxName.Clear();
            textBoxManufacture.Clear();
            textBoxPrice.Clear();

            // Очищаем поля ввода
            textBoxName.Clear();
            textBoxManufacture.Clear();
            textBoxPrice.Clear();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Радиус закругления
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path); // Устанавливаем область кнопки
        }


        private void SearchButton_Click(object? sender, EventArgs e)
        {
            // Получаем поисковый запрос и приводим его к нижнему регистру для нечувствительного к регистру поиска
            string query = textBoxSearch.Text.Trim().ToLower();

            // Если запрос пустой, отображаем все элементы
            if (string.IsNullOrEmpty(query))
            {
                DisplayItems(originalItems);
                return;
            }




            // Фильтруем элементы из originalItems по содержимому в первой колонке или подэлементах
            var filteredItems = originalItems
                .Where(item => item.Text.ToLower().Contains(query) ||
                               item.SubItems.Cast<ListViewItem.ListViewSubItem>()
                                   .Any(subItem => subItem.Text.ToLower().Contains(query)))
                .ToList();

            DisplayItems(filteredItems);
        }

        private void DisplayItems(List<ListViewItem> items)
        {
            // Отключаем обновление отображения для предотвращения мерцания
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var item in items)
            {
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент (например, первый выбранный)
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Удаляем элемент из ListView
                listView1.Items.Remove(selectedItem);

                // Если у вас есть основная коллекция (например, originalItems или componentsList),
                // то найдите соответствующий элемент и удалите его оттуда
                // Например, если уникальным идентификатором является Name:
                var itemToRemove = originalItems.FirstOrDefault(item => item.Text == selectedItem.Text);
                if (itemToRemove != null)
                {
                    originalItems.Remove(itemToRemove);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли данные для сохранения
            if (componentsList == null || componentsList.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Component>));
                using (StreamWriter writer = new StreamWriter("components.xml"))
                {
                    serializer.Serialize(writer, componentsList);
                }
                MessageBox.Show("Данные успешно сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, существует ли файл
            if (!File.Exists("components.xml"))
            {
                MessageBox.Show("Файл с данными не найден. Сначала сохраните данные.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, не пустой ли файл
            FileInfo fileInfo = new FileInfo("components.xml");
            if (fileInfo.Length == 0)
            {
                MessageBox.Show("Файл пустой, нечего загружать.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Component>));
                using (StreamReader reader = new StreamReader("components.xml"))
                {
                    componentsList = (List<Component>)serializer.Deserialize(reader);
                }
                // Обновляем ListView с загруженными данными
                UpdateListView(componentsList);
                MessageBox.Show("Данные успешно загружены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для обновления ListView на основе коллекции компонентов
        private void UpdateListView(IEnumerable<Component> list)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var comp in list)
            {
                string[] row = { comp.Name, comp.Manufacturer, comp.Price.ToString() };
                ListViewItem item = new ListViewItem(row);
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }



        //***************************************
        // Коллекция для хранения объектов Component
        private List<GraphicsCard> graphicsCards = new List<GraphicsCard>();

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            // Проверяем заполненность полей
            if (string.IsNullOrWhiteSpace(textBoxGCName.Text) ||
                string.IsNullOrWhiteSpace(textBoxGCManufacture.Text) ||
                string.IsNullOrWhiteSpace(textBoxGCPrice.Text) ||
                string.IsNullOrWhiteSpace(textBoxVolume.Text) ||
                string.IsNullOrWhiteSpace(textBoxGCType.Text) ||
                string.IsNullOrWhiteSpace(textBoxGCcores.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Преобразуем строковые значения в необходимые числовые типы
            if (!decimal.TryParse(textBoxGCPrice.Text, out decimal price))
            {
                MessageBox.Show("Введите корректное значение цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxVolume.Text, out int memorySize))
            {
                MessageBox.Show("Введите корректное значение объёма памяти!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxGCcores.Text, out int cores))
            {
                MessageBox.Show("Введите корректное значение количества ядер!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Создаем новый объект GraphicsCard и добавляем его в  List
            GraphicsCard newGraphicsCard = new GraphicsCard(textBoxGCName.Text, textBoxGCManufacture.Text, price, memorySize, textBoxGCType.Text, cores);
            graphicsCards.Add(newGraphicsCard);

            // Очистка текстовых полей
            textBoxGCName.Clear();
            textBoxGCManufacture.Clear();
            textBoxGCPrice.Clear();
            textBoxVolume.Clear();
            textBoxGCType.Clear();
            textBoxGCcores.Clear();

            // Обновляем DataGridView с использованием graphicsCards, а не componentsList
            UpdateListViewGC(graphicsCards);
        }

        private void UpdateListViewGC(IEnumerable<GraphicsCard> list)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list.ToList();

            var columnOrder = new Dictionary<string, int>
            {
                { "Name", 0 },
                { "Manufacturer", 1 },
                { "Price", 2 },
                { "MemorySize", 3 },
                { "GCType", 4 },
                { "Cores", 5 }
            };

            foreach (var kvp in columnOrder)
            {
                if (dataGridView1.Columns[kvp.Key] != null)
                    dataGridView1.Columns[kvp.Key].DisplayIndex = kvp.Value;
            }

        }


        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли данные для сохранения
            if (graphicsCards == null || graphicsCards.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
                sfd.Title = "Сохранить данные";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Создаем сериализатор для коллекции GraphicsCard
                        XmlSerializer serializer = new XmlSerializer(typeof(List<GraphicsCard>));
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            serializer.Serialize(writer, graphicsCards);
                        }
                        MessageBox.Show("Данные успешно сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хотя бы одна строка
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите элемент для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем индекс выбранной строки (при режиме FullRowSelect)
            int rowIndex = dataGridView1.SelectedRows[0].Index;
            if (rowIndex >= 0 && rowIndex < graphicsCards.Count)
            {
                // Удаляем объект из списка
                graphicsCards.RemoveAt(rowIndex);
                RefreshDataGridView();
            }
        }

        // Метод для обновления DataGridView
        private void RefreshDataGridView()
        {
            // Чтобы обновить данные, сбрасываем DataSource и присваиваем его заново
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = graphicsCards;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = textBoxGCSearch.Text.Trim().ToLower();

            // Если строка поиска пуста, показываем весь список
            if (string.IsNullOrEmpty(query))
            {
                dataGridView1.DataSource = graphicsCards;
                return;
            }

            // Фильтруем BindingList и создаем новый список
            var filtered = new List<GraphicsCard>();
            foreach (var comp in graphicsCards)
            {
                if (comp.Name.ToLower().Contains(query) || comp.Manufacturer.ToLower().Contains(query))
                {
                    filtered.Add(comp);
                }
            }
            dataGridView1.DataSource = filtered;
        }

        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
                ofd.Title = "Загрузить данные";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Проверяем, существует ли файл и не пуст ли он
                    if (!File.Exists(ofd.FileName))
                    {
                        MessageBox.Show("Файл с данными не найден.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    if (fileInfo.Length == 0)
                    {
                        MessageBox.Show("Файл пустой, нечего загружать.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<GraphicsCard>));
                        using (StreamReader reader = new StreamReader(ofd.FileName))
                        {
                            graphicsCards = (List<GraphicsCard>)serializer.Deserialize(reader);
                        }
                        // Обновляем DataGridView с загруженными данными
                        UpdateListViewGC(graphicsCards);
                        MessageBox.Show("Данные успешно загружены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void checkBoxDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            bool isDark = checkBoxDarkMode.Checked; // Проверяем, включен ли режим
            UpdateTheme(this, isDark); // Вызываем функцию для всей формы

           
        }
        private void UpdateTheme(Control parent, bool isDark)
        {
            // Устанавливаем цвет фона и текста для родительского контейнера
            parent.BackColor = isDark ? Color.FromArgb(46, 51, 73) : Color.White;
            parent.ForeColor = isDark ? Color.White : Color.Black;

            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = isDark ? Color.FromArgb(46, 51, 73) : Color.White;
                    textBox.ForeColor = isDark ? Color.White : Color.Black;
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = isDark ? Color.FromArgb(46, 51, 73) : SystemColors.Control;
                    button.ForeColor = isDark ? Color.White : SystemColors.ControlText;
                }
                else if (control is Label label)
                {
                    label.BackColor = isDark ? Color.FromArgb(46, 51, 73) : SystemColors.Control;
                    label.ForeColor = isDark ? Color.White : Color.Black;
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.BackgroundColor = isDark ? Color.FromArgb(46, 51, 73) : Color.White;
                    dataGridView.DefaultCellStyle.BackColor = isDark ? Color.FromArgb(46, 51, 73) : Color.White;
                    dataGridView.DefaultCellStyle.ForeColor = isDark ? Color.White : Color.Black;
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = isDark ? Color.FromArgb(46, 51, 73) : SystemColors.Control;
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = isDark ? Color.White : SystemColors.ControlText;
                    dataGridView.DefaultCellStyle.SelectionBackColor = isDark ? Color.Gray : SystemColors.Highlight;
                    dataGridView.DefaultCellStyle.SelectionForeColor = isDark ? Color.White : SystemColors.HighlightText;
                }

                // Если элемент содержит вложенные элементы (например, Panel или GroupBox), рекурсивно обновляем их
                if (control.HasChildren)
                {
                    UpdateTheme(control, isDark);
                }
            }
        }
    }
}