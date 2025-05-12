using StoreManager_7lab.Commands;
using StoreManager_7lab.Models;
using StoreManager_7lab.Services; 
using System.Collections.ObjectModel;
using System.ComponentModel; 
using System.Runtime.CompilerServices; 
using System.Windows;
using System.Windows.Input;

namespace StoreManager_7lab.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _api;

        private ObservableCollection<Product> _products = new();
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Order> Orders { get; set; } = new();
        public ObservableCollection<CartItem> CartItems { get; set; } = new();

        // Вводимые данные
        private string _newProductName;
        public string NewProductName
        {
            get => _newProductName;
            set { _newProductName = value; OnPropertyChanged(); }
        }

        private decimal _newProductPrice;
        public decimal NewProductPrice
        {
            get => _newProductPrice;
            set { _newProductPrice = value; OnPropertyChanged(); }
        }

        private int _newProductStock;
        public int NewProductStock
        {
            get => _newProductStock;
            set { _newProductStock = value; OnPropertyChanged(); }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set { _customerName = value; OnPropertyChanged(); }
        }
         

        public ObservableCollection<string> Categories { get; } = new()
        {
            "Ноутбуки", "Комплектующие", "Аксессуары", "Мониторы", "Сеть"
        };

        // Выборы из списка
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
                if (value != null)
                {
                    NewProductName = value.Name;
                    NewProductPrice = value.Price;
                    NewProductStock = value.Stock;
                    SelectedCategory = value.Category;
                }
            }
        }

        private CartItem _selectedCartItem;
        public CartItem SelectedCartItem
        {
            get => _selectedCartItem;
            set { _selectedCartItem = value; OnPropertyChanged(); }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(); }
        }

        // Команды
        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand RemoveFromCartCommand { get; }
        public ICommand AddOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }
        public ICommand ClearFieldsCommand { get; }
        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
         
        private bool _isAdmin;
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                Console.WriteLine($"IsAdmin установлен в: {_isAdmin}");
                OnPropertyChanged();
            }
        }

        public MainViewModel(ApiService api)
        {
            _api = api;



            AddProductCommand = new RelayCommand(async _ => await AddProductAsync(), _ => CanAddProduct());
            UpdateProductCommand = new RelayCommand(async _ => await UpdateProductAsync(), _ => SelectedProduct != null);
            DeleteProductCommand = new RelayCommand(async _ => await DeleteProductAsync(), _ => SelectedProduct != null);
            AddToCartCommand = new RelayCommand(_ => AddToCart(), _ => SelectedProduct != null && SelectedProduct.Stock > 0);
            RemoveFromCartCommand = new RelayCommand(_ => RemoveFromCart(), _ => SelectedCartItem != null);
            AddOrderCommand = new RelayCommand(async _ => await AddOrderAsync(), _ => CartItems.Any() && !string.IsNullOrWhiteSpace(CustomerName));
            DeleteOrderCommand = new RelayCommand(async _ => await DeleteOrderAsync(), _ => SelectedOrder != null);
            ClearFieldsCommand = new RelayCommand(_ => ClearProductFields());
            IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity, CanIncreaseQuantity);
            DecreaseQuantityCommand = new RelayCommand(DecreaseQuantity, CanDecreaseQuantity);



            _ = LoadProductsAsync();
            _ = LoadOrdersAsync();

            IsAdmin = _api.GetRole() == "Admin";
        }

        // ================================
        // Методы
        // ================================

        private async Task LoadProductsAsync()
        {
            try
            { 

                var products = await _api.GetProductsAsync();
                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}");
            }
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await _api.GetOrdersAsync();
                Orders.Clear();
                foreach (var o in orders)
                    Orders.Add(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}");
            }
        }


        private void IncreaseQuantity(object parameter)
        {
            if (parameter is CartItem item && item.Product.Stock > 0)
            {
                item.Quantity++;
                item.Product.Stock--;
                OnPropertyChanged(nameof(CartItems));
                OnPropertyChanged(nameof(Products));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private void DecreaseQuantity(object parameter)
        {
            if (parameter is CartItem item && item.Quantity > 1)
            {
                item.Quantity--;
                item.Product.Stock++;
                OnPropertyChanged(nameof(CartItems));
                OnPropertyChanged(nameof(Products));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private bool CanIncreaseQuantity(object parameter) =>
            parameter is CartItem item && item.Product.Stock > 0;

        private bool CanDecreaseQuantity(object parameter) =>
            parameter is CartItem item && item.Quantity > 1;


        private async Task AddProductAsync()
        {
            var product = new Product
            {
                Name = NewProductName,
                Price = NewProductPrice,
                Stock = NewProductStock,
                Category = SelectedCategory
            };

            await _api.AddProductAsync(product);
            await LoadProductsAsync();
            ClearProductFields();
        }

        private async Task UpdateProductAsync()
        {
            if (SelectedProduct == null) return;

            SelectedProduct.Name = NewProductName;
            SelectedProduct.Price = NewProductPrice;
            SelectedProduct.Stock = NewProductStock;
            SelectedProduct.Category = SelectedCategory;

            await _api.UpdateProductAsync(SelectedProduct);
            await LoadProductsAsync();
            ClearProductFields();
            SelectedProduct = null;
        }

        private async Task DeleteProductAsync()
        {
            if (SelectedProduct == null) return;

            await _api.DeleteProductAsync(SelectedProduct.Id);
            await LoadProductsAsync();
            ClearProductFields();
            SelectedProduct = null;
        }

        private void AddToCart()
        {
            var existing = CartItems.FirstOrDefault(x => x.Product.Id == SelectedProduct.Id);
            if (existing != null)
                existing.Quantity++;
            else
                CartItems.Add(new CartItem { Product = SelectedProduct, Quantity = 1 });

            SelectedProduct.Stock--;
            OnPropertyChanged(nameof(CartItems));
        }

        private void RemoveFromCart()
        {
            if (SelectedCartItem == null) return;

            SelectedCartItem.Product.Stock += SelectedCartItem.Quantity;
            CartItems.Remove(SelectedCartItem);
            SelectedCartItem = null;
            OnPropertyChanged(nameof(CartItems));
        }

        private async Task AddOrderAsync()
        {
            var order = new Order
            {
                CustomerName = CustomerName,
                OrderDate = DateTime.Now,
                Items = CartItems.Select(c => new OrderItem
                {
                    ProductId = c.Product.Id,
                    Quantity = c.Quantity,
                    Product = null,    
                }).ToList()
            };

            try
            {
                await _api.AddOrderAsync(order); // Отправляем заказ на сервер
                MessageBox.Show("✅ Заказ успешно создан.");

                // Затем обновляем список заказов
                await LoadOrdersAsync();

                // Очищаем корзину и форму только после этого
                CartItems.Clear();
                CustomerName = "";
                await LoadProductsAsync(); // обновляем остатки
                OnPropertyChanged(nameof(CartItems));
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Ошибка при создании заказа: " + ex.Message);
            }

            CommandManager.InvalidateRequerySuggested(); // обновляет состояние кнопок
        }



        private async Task DeleteOrderAsync()
        {
            if (SelectedOrder == null) return;
            await _api.DeleteOrderAsync(SelectedOrder.Id);
            await LoadOrdersAsync();
        }

        public void ClearProductFields()
        {
            NewProductName = "";
            NewProductPrice = 0;
            NewProductStock = 0;
            SelectedCategory = null;

            OnPropertyChanged(nameof(NewProductName));
            OnPropertyChanged(nameof(NewProductPrice));
            OnPropertyChanged(nameof(NewProductStock));
            OnPropertyChanged(nameof(SelectedCategory));
        }

        private bool CanAddProduct() =>
            !string.IsNullOrWhiteSpace(NewProductName) &&
            NewProductPrice > 0 &&
            NewProductStock > 0 &&
            !string.IsNullOrWhiteSpace(SelectedCategory);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
