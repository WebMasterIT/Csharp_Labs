using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
