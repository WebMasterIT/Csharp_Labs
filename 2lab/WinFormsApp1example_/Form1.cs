using surname_wfApp.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1example_
{
    public partial class Form1 : Form
    {

        // Новые поля для отфильтрованных списков
        private IEnumerable<object> filteredComponentList = null;
        private IEnumerable<object> filteredGraphicsCardList = null;
        private IEnumerable<object> filteredProcessorsList = null;

        // Флаги для реализации перемещения формы
        private bool dragging = false; // Состояние перетаскивания (активно/неактивно)
        private Point startPoint = new Point(0, 0); // Начальные координаты клика мыши

        // Импорт функции CreateRoundRectRgn для создания закругленных углов формы
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,    // X-координата левого верхнего угла
            int nTopRect,     // Y-координата левого верхнего угла
            int nRightRect,   // X-координата правого нижнего угла
            int nBottomRect,  // Y-координата правого нижнего угла
            int nWidthEllipse,// Ширина эллипса для закругления углов
            int nHeightEllipse// Высота эллипса для закругления углов
        );

        // Импорт функций для перетаскивания формы
        [DllImport("user32.dll")]
        private static extern void ReleaseCapture(); // Сброс захвата мыши

        [DllImport("user32.dll")]
        private static extern void SendMessage(IntPtr hWnd, int msg, int wp, int lp);

        private const int WM_NCLBUTTONDOWN = 0xA1; // Сообщение о нажатии кнопки мыши в незакрашенной области окна
        private const int HTCAPTION = 0x2; // Идентификатор области заголовка окна

        // Обработчик события нажатия мыши на форме
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Включаем режим перетаскивания формы
            dragging = true;
            // Запоминаем начальные координаты клика относительно формы
            startPoint = new Point(e.X, e.Y);
        }

        // Обработчик события движения мыши над формой
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем, активировано ли перетаскивание
            if (dragging)
            {
                // Преобразуем текущие координаты мыши в экранные координаты
                Point newPosition = PointToScreen(new Point(e.X, e.Y));
                // Обновляем позицию формы с учетом начальной точки клика
                // Это позволяет перемещать форму за точку, где был совершен клик
                this.Location = new Point(
                    newPosition.X - startPoint.X,
                    newPosition.Y - startPoint.Y
                );
            }
        }

        // Обработчик события отпускания кнопки мыши
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Выключаем режим перетаскивания
            dragging = false;
        }


        public Form1()
        {
            InitializeComponent();

            dataGridView4.AutoGenerateColumns = false;

            this.FormBorderStyle = FormBorderStyle.None; // Убираем стандартную границу формы
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));


        }
        //Закрытие окна формы
        private void extBtn_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void HideAllPanels()
        {
            componentsPanel.Visible = false;
            graphicsCardPanel.Visible = false;
            processorsPanel.Visible = false;
            ramPanel.Visible = false;
        }

        //Кнопки переключения вкладок
        private void componentTabBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            componentsPanel.Visible = true;
        }

        private void GraphicsCardTabBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            graphicsCardPanel.Visible = true;
        }

        private void ramTabBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ramPanel.Visible = true;
        }

        private void processorsTabBtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            processorsPanel.Visible = true;
        }
        //Кнопки переключения вкладок

        //Стилизация: смена цвета label внутри groupbox 
        private void ChangeControlsForeColor(System.Windows.Forms.GroupBox groupBox, Color color)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (!(control is System.Windows.Forms.TextBox) && !(control is System.Windows.Forms.Button)) // Исключаем TextBox и Button
                {
                    control.ForeColor = color;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Стилизация GroupBox
            ChangeControlsForeColor(groupBoxGC, Color.White);
            groupBox12.ForeColor = this.BackColor; // Цвет рамки в цвет формы
            groupBoxGC.ForeColor = this.BackColor; // Цвет рамки в цвет формы

            //связывают кнопки сохранения/загрузки с DataGridView, к которому они относятся.
            cmponentSave.Tag = dataGridView1;
            componentLoad.Tag = dataGridView1;

            // Устанавливаем привязку столбцов к свойствам объекта Processor
            dataGridView4.Columns["Name"].DataPropertyName = "Name";
            dataGridView4.Columns["Manufacturer"].DataPropertyName = "Manufacturer";
            dataGridView4.Columns["Price"].DataPropertyName = "Price";
            dataGridView4.Columns["Frequency"].DataPropertyName = "Frequency";
            dataGridView4.Columns["Cores"].DataPropertyName = "Cores";
        }
         
        // Список компонентов (например, процессоры, видеокарты и т.д.)
        private List<Component> componentList = new List<Component>();

        private void componentAddBtn_Click_1(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            // Проверяем заполненность полей
            if (string.IsNullOrWhiteSpace(componentNameText.Text) ||
                string.IsNullOrWhiteSpace(componentManufactureText.Text) ||
                string.IsNullOrWhiteSpace(componentPriceText.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем строковые значения в необходимые числовые типы
            if (!decimal.TryParse(componentPriceText.Text, out decimal price))
            {
                MessageBox.Show("Введите корректное значение цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новый объект Component и добавляем его в List
            Component newComponent = new Component(componentNameText.Text, componentManufactureText.Text, price);
            componentList.Add(newComponent);

            // Очистка текстовых полей
            componentNameText.Clear();
            componentManufactureText.Clear();
            componentPriceText.Clear();

            // Обновляем DataGridView
            filteredComponentList = null; // Сбрасываем фильтр после добавления
            UpdateDataGrid();
        }

        private void FormatPriceCell(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что индекс корректен
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgv.Columns.Count)
                return;

            // Проверяем колонку "Price" и наличие значения
            if (dgv.Columns[e.ColumnIndex].Name == "Price" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = price.ToString("N2") + " ₽";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatPriceCell(dataGridView1, e);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatPriceCell(dataGridView2, e);
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatPriceCell(dataGridView4, e);
        }

        private void UpdateDataGrid()
        { 
            // Переменные для хранения активного DataGridView и списка данных
            DataGridView activeGridView = null;
            IEnumerable<object> activeList = null;

            // Определяем, какой DataGridView и список данных использовать
            if (componentsPanel.Visible) // Панель компонентов
            {
                activeGridView = dataGridView1;
                activeList = filteredComponentList ?? componentList; 
                // Используем отфильтрованный список, если он существует
            }
            else if (graphicsCardPanel.Visible) // Панель видеокарт
            {
                activeGridView = dataGridView2;
                activeList = filteredGraphicsCardList ?? graphicsCardList;
            }
            else if (processorsPanel.Visible) // Панель процессоров
            {
                activeGridView = dataGridView4;
                activeList = filteredProcessorsList ?? processorsList;
            }

            // Если активный DataGridView и список определены
            if (activeGridView != null && activeList != null)
            {
                // Сбрасываем привязку данных
                activeGridView.DataSource = null;

                // Присваиваем обновленный список данных DataGridView
                activeGridView.DataSource = activeList.ToList(); // Преобразуем в список, если это не List<T>
            }
            // Очистить все строки, чтобы избежать дублирования данных
            dataGridView4.DataSource = null;

            // Добавляем новые строки вручную для каждого объекта в списке
            foreach (var processor in processorsList)
            {
                // Добавляем строку и указываем значения для каждого столбца
                dataGridView4.Rows.Add(processor.Name, processor.Manufacturer, 
                    processor.Price, processor.Frequency, processor.Cores);
            }
        }


        private void componentSearchBtn_Click(object sender, EventArgs e)
        {
            string query = string.Empty; // Объявляем переменную для хранения поискового запроса

            // Определяем активную панель и берём текст из соответствующего поля ввода
            if (componentsPanel.Visible) // Если активна панель компонентов
                query = componentSearchText.Text.Trim().ToLower(); // Получаем текст из поля поиска компонентов,
                                                                   // убираем пробелы и приводим к нижнему регистру
            else if (graphicsCardPanel.Visible) // Если активна панель видеокарт
                query = GCSearchText.Text.Trim().ToLower(); // Получаем текст из поля поиска видеокарт,
                                                            // убираем пробелы и приводим к нижнему регистру
            else if (processorsPanel.Visible) // Если активна панель процессоров
                query = processorSearchText.Text.Trim().ToLower(); // Получаем текст из поля поиска процессоров,
                                                                   // убираем пробелы и приводим к нижнему регистру
            else // Если ни одна панель не активна
                return; // Завершаем выполнение метода

            // Проверяем, пустой ли запрос
            if (string.IsNullOrEmpty(query)) // Если запрос пустой
            {
                filteredComponentList = null; // Сбрасываем фильтр для компонентов
                filteredGraphicsCardList = null; // Сбрасываем фильтр для видеокарт
                filteredProcessorsList = null; // Сбрасываем фильтр для процессоров
                UpdateDataGrid(); // Обновляем таблицу для отображения полного списка
                return; // Завершаем выполнение метода
            }

            // Выполняем фильтрацию в зависимости от активной панели
            if (componentsPanel.Visible) // Если активна панель компонентов
            {
                filteredComponentList = componentList.Where(comp => // Фильтруем список компонентов
                    comp.Name.ToLower().Contains(query) || // Поиск по имени (без учёта регистра)
                    comp.Manufacturer.ToLower().Contains(query) || // Поиск по производителю (без учёта регистра)
                    comp.Price.ToString().Contains(query) // Поиск по цене (как строке)
                ).ToList(); // Преобразуем результат в список
            }
            else if (graphicsCardPanel.Visible) // Если активна панель видеокарт
            { 

                filteredGraphicsCardList = graphicsCardList.Where(gc => // Фильтруем список видеокарт
                    gc.Name.ToLower().Contains(query) || // Поиск по имени (без учёта регистра)
                    gc.Manufacturer.ToLower().Contains(query) || // Поиск по производителю (без учёта регистра)
                    gc.Price.ToString().Contains(query) || // Поиск по цене (как строке)
                    gc.MemorySize.ToString().Contains(query) || // Поиск по объёму памяти (как строке)
                    gc.Type.ToLower().Contains(query) || // Поиск по типу памяти (без учёта регистра)
                    gc.BusWidth.ToString().Contains(query) // Поиск по ширине шины (как строке)
                ).ToList(); // Преобразуем результат в список
                
            }
            else if (processorsPanel.Visible) // Если активна панель процессоров
            {
                filteredProcessorsList = processorsList.Where(proc => // Фильтруем список процессоров
                    proc.Name.ToLower().Contains(query) || // Поиск по имени (без учёта регистра)
                    proc.Manufacturer.ToLower().Contains(query) || // Поиск по производителю (без учёта регистра)
                    proc.Price.ToString().Contains(query) || // Поиск по цене (как строке)
                    proc.Frequency.ToString().Contains(query) || // Поиск по частоте (как строке)
                    proc.Cores.ToString().Contains(query) // Поиск по количеству ядер (как строке)
                ).ToList(); // Преобразуем результат в список
            }

            UpdateDataGrid(); // Обновляем таблицу для отображения отфильтрованных данных
        } 




        private void componentDeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите элемент для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранную строку из DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            // Получаем объект Component из DataSource строки
            Component selectedComponent = (Component)selectedRow.DataBoundItem;

            // Удаляем объект из основного списка
            componentList.Remove(selectedComponent);
            filteredComponentList = null; // Сбрасываем фильтр
            UpdateDataGrid(); // Обновляем таблицу
        }
         
        private List<GraphicsCard> graphicsCardList = new List<GraphicsCard>();

        private void button9_Click(object sender, EventArgs e)
        {

            // Проверяем заполненность полей
            if (
                string.IsNullOrWhiteSpace(graphicsCardMemorySizeText.Text.Trim()) ||
                string.IsNullOrWhiteSpace(graphicsCardTypeText.Text.Trim()) ||
                string.IsNullOrWhiteSpace(graphicsCardBusWidthText.Text.Trim()))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем строковые значения в необходимые числовые типы
            if (!int.TryParse(graphicsCardMemorySizeText.Text.Trim(), out int memorySize) ||
                !int.TryParse(graphicsCardBusWidthText.Text.Trim(), out int busWidth) ||
                !decimal.TryParse(graphicsCardPrice.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Некорректные числовые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новый объект GraphicsCard и добавляем его в List
            GraphicsCard newGraphicsCard = new GraphicsCard
            {
                MemorySize = memorySize,
                Type = graphicsCardTypeText.Text,
                BusWidth = busWidth
            };
            graphicsCardList.Add(newGraphicsCard);

            // Очищаем поля ввода
            graphicsCardName.Clear();
            graphicsCardManufacturer.Clear();
            graphicsCardPrice.Clear();
            graphicsCardMemorySizeText.Clear();
            graphicsCardTypeText.Clear();
            graphicsCardBusWidthText.Clear();

            // Обновляем DataGridView
            filteredGraphicsCardList = null; // Сбрасываем фильтр после добавления
            //UpdateDataGrid();
        }




        private List<Processor> processorsList = new List<Processor>();
        private void processorAddBtn_Click(object sender, EventArgs e)
        {
            // Проверка на заполненность всех полей
            if (string.IsNullOrWhiteSpace(processorNameText.Text) ||
                string.IsNullOrWhiteSpace(processorManufacturerText.Text) ||
                string.IsNullOrWhiteSpace(processorPriceText.Text) ||
                string.IsNullOrWhiteSpace(processorFrequencyText.Text) ||
                string.IsNullOrWhiteSpace(processorCoresText.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Парсим числовые значения
            if (!decimal.TryParse(processorPriceText.Text.Trim(), out decimal price) || // Price должен быть decimal
                !double.TryParse(processorFrequencyText.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double frequency) ||
                !int.TryParse(processorCoresText.Text.Trim(), out int cores))
            {
                MessageBox.Show("Проверьте числовые значения!\n" +
                                $"Цена: {processorPriceText.Text}\n" +
                                $"Частота: {processorFrequencyText.Text}\n" +
                                $"Ядра: {processorCoresText.Text}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаём объект процессора
            Processor newProcessor = new Processor
            {
                Name = processorNameText.Text,
                Manufacturer = processorManufacturerText.Text,
                Price = price, // Теперь decimal
                Frequency = frequency,
                Cores = cores
            };

            // Добавляем в список
            processorsList.Add(newProcessor);

            // Очищаем поля
            processorNameText.Clear();
            processorManufacturerText.Clear();
            processorPriceText.Clear();
            processorFrequencyText.Clear();
            processorCoresText.Clear();

            // Сбрасываем фильтр и обновляем DataGridView
            filteredProcessorsList = null; // Сбрасываем фильтр, чтобы новый элемент отобразился
            UpdateDataGrid();
        }


        private void LoadDataGridView(DataGridView dgv) // Метод для загрузки данных из XML-файла в список,
                                                        // привязанный к переданному DataGridView
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Создаём диалог для выбора файла пользователем
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"; // Устанавливаем фильтр:
                                                                                   // XML-файлы по умолчанию, с опцией "все файлы"

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Открываем диалог и проверяем, выбрал ли пользователь файл
            {
                string filePath = openFileDialog.FileName; // Получаем путь к выбранному файлу (например, "C:\data.xml")

                if (dgv == null) // Проверяем, передан ли действительный DataGridView
                {
                    MessageBox.Show("Передан некорректный DataGridView для загрузки данных."); // Если dgv null, показываем ошибку
                    return; // Завершаем выполнение
                }

                // Загружаем данные в соответствующий список в зависимости от переданного DataGridView
                if (dgv == dataGridView1) // Если передан DataGridView для компонентов
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Component>)); // Создаём сериализатор для List<Component>
                    using (TextReader reader = new StreamReader(filePath)) // Открываем поток чтения из файла
                    {
                        componentList = (List<Component>)serializer.Deserialize(reader); // Десериализуем XML в componentList
                    }
                    filteredComponentList = null; // Сбрасываем фильтр для отображения полного списка
                }
                else if (dgv == dataGridView2) // Если передан DataGridView для видеокарт
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<GraphicsCard>)); // Создаём сериализатор для List<GraphicsCard>
                    using (TextReader reader = new StreamReader(filePath)) // Открываем поток чтения
                    {
                        graphicsCardList = (List<GraphicsCard>)serializer.Deserialize(reader); // Десериализуем XML в graphicsCardList
                    }
                    filteredGraphicsCardList = null; // Сбрасываем фильтр
                }
                else if (dgv == dataGridView4) // Если передан DataGridView для процессоров
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Processor>)); // Создаём сериализатор для List<Processor>
                    using (TextReader reader = new StreamReader(filePath)) // Открываем поток чтения
                    {
                        processorsList = (List<Processor>)serializer.Deserialize(reader); // Десериализуем XML в processorsList
                    }
                    filteredProcessorsList = null; // Сбрасываем фильтр
                }
                else // Если передан неизвестный DataGridView
                {
                    MessageBox.Show("Неизвестный DataGridView для загрузки данных."); // Сообщаем об ошибке
                    return; // Завершаем выполнение
                }

                UpdateDataGrid(); // Обновляем активный DataGridView с новыми данными
                MessageBox.Show("Данные успешно загружены."); // Сообщаем об успехе
            }
        }

        private void componentLoad_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn && btn.Tag is DataGridView dgv)
            {
                LoadDataGridView(dgv);
            }
        }
 
        private void SaveDataGridView(DataGridView dgv)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Создаём объект SaveFileDialog для выбора пользователем пути и имени файла
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"; // Устанавливаем фильтр для отображения
                                                                                   // XML-файлов по умолчанию и опции "все файлы"

            if (saveFileDialog.ShowDialog() == DialogResult.OK) // Открываем диалог сохранения и проверяем, выбрал ли пользователь файл (нажал "ОК")
            {
                string filePath = saveFileDialog.FileName; // Получаем полный путь к файлу, выбранному пользователем (например, "C:\data.xml")

                if (dgv == null) // Проверяем, был ли передан действительный DataGridView (не null)
                {
                    MessageBox.Show("Нет доступных DataGridView для сохранения."); // Если DataGridView не передан, показываем сообщение об ошибке
                    return; // Завершаем выполнение метода
                }

                // Выбираем, какой список сериализовать в зависимости от переданного DataGridView
                if (dgv == dataGridView1) // Если передан DataGridView для компонентов (dataGridView1)
                {
                    if (componentList.Count == 0) // Проверяем, содержит ли список componentList данные
                    {
                        MessageBox.Show("Нет данных для сохранения."); // Если список пуст, показываем сообщение
                        return; // Завершаем выполнение метода
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Component>)); // Создаём XmlSerializer для сериализации
                                                                                           // списка List<Component> в XML
                    using (TextWriter writer = new StreamWriter(filePath)) // Создаём TextWriter (StreamWriter) для записи данных в файл
                    {
                        serializer.Serialize(writer, componentList); // Сериализуем componentList в XML и записываем в файл
                    } // Автоматически закрываем writer благодаря using
                    MessageBox.Show("Данные успешно сохранены."); // Сообщаем пользователю об успешном сохранении
                }
                else if (dgv == dataGridView2) // Если передан DataGridView для видеокарт (dataGridView2)
                {
                    if (graphicsCardList.Count == 0) // Проверяем, содержит ли список graphicsCardList данные
                    {
                        MessageBox.Show("Нет данных для сохранения."); // Если список пуст, показываем сообщение
                        return; // Завершаем выполнение
                    }
                    Debug.WriteLine($"Graphics cards count: {graphicsCardList.Count}");

                    XmlSerializer serializer = new XmlSerializer(typeof(List<GraphicsCard>)); // Создаём XmlSerializer для сериализации
                                                                                              // списка List<GraphicsCard> в XML
                    using (TextWriter writer = new StreamWriter(filePath)) // Создаём TextWriter для записи данных в файл
                    {
                        serializer.Serialize(writer, graphicsCardList); // Сериализуем graphicsCardList в XML и записываем в файл
                    } // Закрываем writer
                    MessageBox.Show("Данные успешно сохранены."); // Сообщаем об успешном сохранении
                }
                else if (dgv == dataGridView4) // Если передан DataGridView для процессоров (dataGridView4)
                {
                    if (processorsList.Count == 0) // Проверяем, содержит ли список processorsList данные
                    {
                        MessageBox.Show("Нет данных для сохранения."); // Если список пуст, показываем сообщение
                        return; // Завершаем выполнение
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Processor>)); // Создаём XmlSerializer для сериализации
                                                                                           // списка List<Processor> в XML
                    using (TextWriter writer = new StreamWriter(filePath)) // Создаём TextWriter для записи данных в файл
                    {
                        serializer.Serialize(writer, processorsList); // Сериализуем processorsList в XML и записываем в файл
                    } // Закрываем writer
                    MessageBox.Show("Данные успешно сохранены."); // Сообщаем об успешном сохранении
                }
            }
        }

        private void cmponentSave_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn && btn.Tag is DataGridView dgv)
            {
                SaveDataGridView(dgv);
            }
        } 
        private void graphicsCardDeletBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите элемент для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранную строку из DataGridView
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            // Получаем объект GraphicsCard из DataSource строки
            GraphicsCard selectedGraphicsCard = (GraphicsCard)selectedRow.DataBoundItem;

            // Удаляем объект из основного списка
            graphicsCardList.Remove(selectedGraphicsCard);
            filteredGraphicsCardList = null; // Сбрасываем фильтр
            UpdateDataGrid(); // Обновляем таблицу
        }

        private void processorSave(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn && btn.Tag is DataGridView dgv)
            {
                SaveDataGridView(dgv);
            }
        }

        private void HandleSaveOrLoad_Click(object sender, EventArgs e, Action<DataGridView> action)
        {
            if (sender is System.Windows.Forms.Button btn && btn.Tag is DataGridView dgv)
            {
                action(dgv);
            }
        }
       

    }
}
