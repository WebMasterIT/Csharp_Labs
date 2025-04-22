using StoreManager.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreManager
{
    // Главное окно приложения для управления товарами и заказами
    public partial class MainWindow : Window
    {
        // Список всех товаров
        private List<Product> products = new List<Product>();
        // Список всех заказов
        private List<Order> orders = new List<Order>();
        // Следующий ID для нового товара
        private int nextProductId = 1;
        // Следующий ID для нового заказа
        private int nextOrderId = 1;
        // Список выбранных товаров для текущего заказа
        private List<OrderItem> selectedProductsForOrder = new List<OrderItem>();

        // Конструктор окна
        public MainWindow()
        {
            InitializeComponent(); // Инициализация UI
            UpdateProductList();   // Обновление списка товаров
            UpdateOrderList();    // Обновление списка заказов
            UpdateSelectedProductsList(); // Обновление списка выбранных товаров
        }

        // Обновляет отображение списка товаров
        private void UpdateProductList()
        {
            ProductsList.ItemsSource = null;
            ProductsList.ItemsSource = products;
        }

        // Обновляет отображение списка заказов
        private void UpdateOrderList()
        {
            OrdersList.ItemsSource = null;
            OrdersList.ItemsSource = orders;
        }

        // Обновляет отображение списка выбранных товаров
        private void UpdateSelectedProductsList()
        {
            SelectedProductsList.ItemsSource = null;
            SelectedProductsList.ItemsSource = selectedProductsForOrder;
        }

        // Обработчик нажатия кнопки "Добавить товар"
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Проверка корректности введённых данных
            if (string.IsNullOrWhiteSpace(ProductName.Text) ||
                !decimal.TryParse(ProductPrice.Text, out decimal price) ||
                !int.TryParse(ProductStock.Text, out int stock) ||
                stock < 0)
            {
                MessageBox.Show("Пожалуйста, введите корректные данные о товаре. Остаток не может быть отрицательным.", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            // Создание нового товара
            var product = new Product
            {
                Id = nextProductId++,
                Name = ProductName.Text,
                Price = price,
                Stock = stock
            };

            products.Add(product); // Добавление товара в список
            UpdateProductList();    // Обновление UI
            ClearProductFields();   // Очистка полей ввода
        }

        // Обработчик нажатия кнопки "Обновить товар"
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product selectedProduct)
            {
                // Проверка корректности введённых данных
                if (string.IsNullOrWhiteSpace(ProductName.Text) ||
                    !decimal.TryParse(ProductPrice.Text, out decimal price) ||
                    !int.TryParse(ProductStock.Text, out int stock) ||
                    stock < 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректные данные о товаре. Остаток не может быть отрицательным.", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Обновление свойств выбранного товара
                selectedProduct.Name = ProductName.Text;
                selectedProduct.Price = price;
                selectedProduct.Stock = stock;

                UpdateProductList();  // Обновление UI
                ClearProductFields(); // Очистка полей ввода
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик нажатия кнопки "Удалить товар"
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product selectedProduct)
            {
                // Проверка, используется ли товар в заказах
                if (orders.Any(order => order.Items.Any(item => item.Product.Id == selectedProduct.Id)))
                {
                    MessageBox.Show("Нельзя удалить товар, используемый в заказах.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить товар '{selectedProduct.Name}'?", 
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    selectedProductsForOrder.RemoveAll(item => item.Product.Id == selectedProduct.Id); // Удаление из текущего заказа
                    products.Remove(selectedProduct); // Удаление из списка товаров
                    UpdateProductList();
                    UpdateSelectedProductsList();
                    ClearProductFields();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик изменения выделения в списке товаров
        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product selectedProduct)
            {
                // Заполнение полей ввода данными выбранного товара
                ProductName.Text = selectedProduct.Name;
                ProductPrice.Text = selectedProduct.Price.ToString();
                ProductStock.Text = selectedProduct.Stock.ToString();
            }
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product selectedProduct)
            {
                if (selectedProduct.Stock <= 0)
                {
                    MessageBox.Show("Товара больше нет на складе.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var existingItem = selectedProductsForOrder.FirstOrDefault(item => item.Product.Id == selectedProduct.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    selectedProductsForOrder.Add(new OrderItem { Product = selectedProduct, Quantity = 1 });
                }

                selectedProduct.Stock--; // <=== уменьшение запаса
                UpdateProductList();
                UpdateSelectedProductsList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для добавления в заказ.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик нажатия кнопки "Создать заказ"
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            // Проверка имени клиента
            if (string.IsNullOrWhiteSpace(CustomerName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя клиента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка наличия товаров в заказе
            if (!selectedProductsForOrder.Any())
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один товар для заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создание нового заказа
            var order = new Order
            {
                Id = nextOrderId++,
                CustomerName = CustomerName.Text,
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>(selectedProductsForOrder)
            };
             
            orders.Add(order); // Добавление заказа в список
            UpdateProductList();
            UpdateOrderList();
            ClearOrderFields(); // Очистка полей заказа
        }

        // Обработчик нажатия кнопки "Обновить заказ"
        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersList.SelectedItem is Order selectedOrder)
            {
                // Проверка имени клиента
                if (string.IsNullOrWhiteSpace(CustomerName.Text))
                {
                    MessageBox.Show("Пожалуйста, введите имя клиента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверка наличия товаров
                if (!selectedProductsForOrder.Any())
                {
                    MessageBox.Show("Пожалуйста, выберите хотя бы один товар для заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Обновление заказа
                selectedOrder.CustomerName = CustomerName.Text;
                selectedOrder.OrderDate = DateTime.Now;
                selectedOrder.Items.Clear();
                selectedOrder.Items.AddRange(selectedProductsForOrder); 

                // Проверка доступности перед применением изменений
                foreach (var item in selectedProductsForOrder)
                {
                    int availableStock = item.Product.Stock +
                        selectedOrder.Items.Where(i => i.Product.Id == item.Product.Id).Sum(i => i.Quantity); // учитываем старый заказ

                    if (item.Quantity > availableStock)
                    {
                        MessageBox.Show($"Недостаточно товара '{item.Product.Name}' на складе для обновления заказа.", 
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                        return;
                    }
                }

                UpdateProductList();
                UpdateOrderList();
                ClearOrderFields();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик нажатия кнопки "Удалить заказ"
        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersList.SelectedItem is Order selectedOrder)
            {
                // Подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить заказ для клиента '{selectedOrder.CustomerName}'?", 
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Возврат запасов
                    foreach (var item in selectedOrder.Items)
                    {
                        item.Product.Stock += item.Quantity;
                    }

                    orders.Remove(selectedOrder); // Удаление заказа
                    UpdateProductList();
                    UpdateOrderList();
                    ClearOrderFields();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик нажатия кнопки "Удалить товар из заказа"
        private void RemoveProductFromOrder_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProductsList.SelectedItem is OrderItem selectedItem)
            {
                // Проверка: это последний товар в заказе?
                if (selectedProductsForOrder.Count == 1 && OrdersList.SelectedItem is Order selectedOrder)
                {
                    var result = MessageBox.Show(
                        $"Удаление последнего товара приведёт к удалению заказа клиента '{selectedOrder.CustomerName}'. Продолжить?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result != MessageBoxResult.Yes)
                        return;

                    // Удаляем товар и возвращаем остаток
                    selectedProductsForOrder.Remove(selectedItem);
                    selectedItem.Product.Stock += selectedItem.Quantity;

                    // Удаляем сам заказ
                    orders.Remove(selectedOrder);
                    UpdateProductList();
                    UpdateOrderList();
                    ClearOrderFields();
                }
                else
                {
                    // Обычное удаление товара
                    selectedProductsForOrder.Remove(selectedItem);
                    selectedItem.Product.Stock += selectedItem.Quantity;

                    UpdateProductList();
                    UpdateSelectedProductsList();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления из заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        // Обработчик нажатия кнопки "+" для увеличения количества
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is OrderItem item)
            {
                if (item.Product.Stock < 1)
                {
                    MessageBox.Show("Товара больше нет на складе.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                item.Quantity++;
                item.Product.Stock--; // резерв
                UpdateProductList();
                UpdateSelectedProductsList();
            }
        }

        // Обработчик нажатия кнопки "-" для уменьшения количества
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is OrderItem item)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--; // Уменьшение количества
                }
                else
                {
                    selectedProductsForOrder.Remove(item); // Удаление товара
                }
                item.Product.Stock++;
                UpdateProductList();
                UpdateSelectedProductsList();
            }
        }

        // Обработчик изменения выделения в списке заказов
        private void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersList.SelectedItem is Order selectedOrder)
            {
                // Заполнение полей данными выбранного заказа
                CustomerName.Text = selectedOrder.CustomerName;
                selectedProductsForOrder.Clear();
                selectedProductsForOrder.AddRange(selectedOrder.Items);
                UpdateSelectedProductsList();
            }
        }

        // Очистка полей ввода для товаров
        private void ClearProductFields()
        {
            ProductName.Text = "";
            ProductPrice.Text = "";
            ProductStock.Text = "";
            ProductsList.SelectedItem = null; // Сброс выделения
        }

        // Очистка полей ввода для заказов
        private void ClearOrderFields()
        {
            CustomerName.Text = "";
            selectedProductsForOrder.Clear();
            UpdateSelectedProductsList();
            OrdersList.SelectedItem = null; // Сброс выделения
            // Выделение в ProductsList не сбрасывается
        }

        // Обработчик клика мышью по списку товаров
        private void ProductsList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as ListBox;
            var hitTestResult = VisualTreeHelper.HitTest(listBox, e.GetPosition(listBox));
            if (hitTestResult != null)
            {
                // Проверка, попал ли клик на ListBoxItem
                var element = hitTestResult.VisualHit;
                while (element != null && !(element is ListBoxItem))
                {
                    element = VisualTreeHelper.GetParent(element);
                }

                if (element == null)
                {
                    listBox.SelectedItem = null; // Сброс выделения при клике по пустому месту
                }
            }
        }
    }
}