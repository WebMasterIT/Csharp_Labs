    using StoreManager_4lab.Data;
    using StoreManager_4lab.Models;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Runtime.CompilerServices; 
    using Microsoft.EntityFrameworkCore;
    using System.Windows;

    namespace StoreManager_4lab.ViewModels
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private readonly StoreDbContext _context = new();

            // Коллекции
            public ObservableCollection<Product> Products { get; set; } = new();
            public ObservableCollection<Order> Orders { get; set; } = new();
            public ObservableCollection<OrderItem> SelectedOrderItems { get; set; } = new();
         

            public ObservableCollection<CartItem> CartItems { get; } = new();


            private CartItem _selectedCartItem;

            // Категории
            public ObservableCollection<string> Categories { get; } = new()
            {
                "Ноутбуки и ультрабуки", "Комплектующие для ПК", "Периферия и аксессуары", "Мониторы и дисплеи", "Сетевое оборудование"
            };

            // === Поля товара ===
            private string _newProductName;
            public string NewProductName
            {
                get => _newProductName;
                set
                {
                    _newProductName = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }

            private decimal _newProductPrice;
            public decimal NewProductPrice
            {
                get => _newProductPrice;
                set
                {
                    _newProductPrice = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }

            private int _newProductStock;
            public int NewProductStock
            {
                get => _newProductStock;
                set
                {
                    _newProductStock = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }

            private string _selectedCategory;
            public string SelectedCategory
            {
                get => _selectedCategory;
                set
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }



            public CartItem SelectedCartItem
            {
                get => _selectedCartItem;
                set
                {
                    _selectedCartItem = value;
                    Console.WriteLine($"SelectedCartItem изменен: {(_selectedCartItem != null ? _selectedCartItem.Product.Name : "null")}");
                    OnPropertyChanged(nameof(SelectedCartItem));
                    CommandManager.InvalidateRequerySuggested(); // Обновить состояние команд
                }
            }

            // === Поля заказа ===
            private string _customerName;
            public string CustomerName
            {
                get => _customerName;
                set
                {
                    _customerName = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }

            private Order _selectedOrder;
            public Order SelectedOrder
            {
                get => _selectedOrder;
                set
                {
                    _selectedOrder = value;
                    OnPropertyChanged();
                    SelectedOrderItems.Clear();

                    if (value != null)
                    {
                        foreach (var item in value.Items)
                        {
                            SelectedOrderItems.Add(new OrderItem
                            {
                                ProductId = item.ProductId,
                                Quantity = item.Quantity
                            });
                        }
                    }
                }
            }

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

                    CommandManager.InvalidateRequerySuggested();
                }
            }

            // === Команды ===
            public ICommand AddProductCommand { get; }
            public ICommand AddOrderCommand { get; }
            public ICommand DeleteOrderCommand { get; }
            public ICommand UpdateProductCommand { get; }
            public ICommand DeleteProductCommand { get; }
            public ICommand ClearFieldsCommand { get; }
            public ICommand AddToOrderCommand { get; }
            public ICommand IncreaseQuantityCommand { get; }
            public ICommand DecreaseQuantityCommand { get; }
            public ICommand RemoveFromOrderCommand { get; }
         
            public ICommand AddToCartCommand { get; }

            public ICommand RemoveFromCartCommand { get; }

            public MainViewModel()
            {

                AddProductCommand = new RelayCommand(_ => AddProduct(), _ => CanAddProduct() && SelectedProduct == null);
                AddOrderCommand = new RelayCommand(_ => AddOrder());
                DeleteOrderCommand = new RelayCommand(_ => DeleteOrder(), _ => SelectedOrder != null);
                UpdateProductCommand = new RelayCommand(_ => UpdateProduct(), _ => SelectedProduct != null);
                DeleteProductCommand = new RelayCommand(_ => DeleteProduct(), _ => SelectedProduct != null);
                ClearFieldsCommand = new RelayCommand(_ => ClearProductFields()); 

 
                _context = new StoreDbContext();
                _context.Database.EnsureCreated();

                // Используем лямбда-выражения для согласования сигнатур с RelayCommand    
                AddToCartCommand = new RelayCommand(_ => AddToCart(), _ => CanAddToCart());
                RemoveFromCartCommand = new RelayCommand(_ => RemoveFromCart(), _ => CanRemoveFromCart());
                // Команды с параметрами
                IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity, CanIncreaseQuantity);
                DecreaseQuantityCommand = new RelayCommand(DecreaseQuantity, CanDecreaseQuantity);

           
                _context.Database.EnsureCreated();
                LoadProducts(); 
                LoadOrders();
            }

            private void LoadProducts()
            {
                Products.Clear();
                foreach (var p in _context.Products.ToList())
                    Products.Add(p);
            }


            private void LoadOrders()
            {
                Orders.Clear();
                var allOrders = _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();

                foreach (var order in allOrders)
                    Orders.Add(order);
            }

            private void AddProduct()
            {
                if (string.IsNullOrWhiteSpace(NewProductName))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (NewProductPrice <= 0)
                {
                    MessageBox.Show("Цена должна быть больше 0.");
                    return;
                }

                if (NewProductStock <= 0)
                {
                    MessageBox.Show("Количество должно быть больше 0.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(SelectedCategory))
                {
                    MessageBox.Show("Выберите категорию.");
                    return;
                }

                var product = new Product
                {
                    Name = NewProductName,
                    Price = NewProductPrice,
                    Stock = NewProductStock,
                    Category = SelectedCategory
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                LoadProducts(); 
                ClearProductFields();
            }

         

         
            private void UpdateProduct()
            {
                if (SelectedProduct != null)
                {
                    var product = _context.Products.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                    if (product != null)
                    {
                        product.Name = NewProductName;
                        product.Price = NewProductPrice;
                        product.Stock = NewProductStock;
                        product.Category = SelectedCategory;

                        _context.SaveChanges();

                        LoadProducts();         // <== перезагрузи
                        SelectedProduct = null; // сброси выбор
                        ClearProductFields();
                    }
                }
            }

            private void DeleteProduct()
            {
                if (SelectedProduct != null)
                {
                    bool usedInOrder = _context.OrderItems
                        .Any(oi => oi.Product.Id == SelectedProduct.Id);

                    if (usedInOrder)
                    {
                        System.Windows.MessageBox.Show("Нельзя удалить товар, который используется в заказах.");
                        return;
                    }

                    var product = _context.Products.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                    if (product != null)
                    {
                        _context.Products.Remove(product);
                        _context.SaveChanges();
                        LoadProducts();
                    }

                    SelectedProduct = null;
                    ClearProductFields();
                }
            }

            private bool CanAddProduct()
            {
                return !string.IsNullOrWhiteSpace(NewProductName) && NewProductPrice >= 0 && NewProductStock >= 0;
            }


            private bool CanIncreaseQuantity(object parameter)
            {
                return parameter is CartItem item && item.Quantity < item.Product.Stock;
            }

            private bool CanDecreaseQuantity(object parameter)
            {
                return parameter is CartItem item && item.Quantity > 1;
            }

            private void IncreaseQuantity(object parameter)
            {
                if (parameter is CartItem item && item.Quantity < item.Product.Stock)
                {
                    item.Quantity++;
                    item.Product.Stock--;
                    Console.WriteLine($"Увеличено кол-во: {item.Product.Name}, Кол-во: {item.Quantity}");
                    OnPropertyChanged(nameof(CartItems));
                    OnPropertyChanged(nameof(Products));
                }
            }
            private void DecreaseQuantity(object parameter)
            {
                if (parameter is CartItem item && item.Quantity > 1)
                {
                    item.Quantity--;
                    item.Product.Stock++;
                    Console.WriteLine($"Уменьшено кол-во: {item.Product.Name}, Кол-во: {item.Quantity}");
                    OnPropertyChanged(nameof(CartItems));
                    OnPropertyChanged(nameof(Products));
                }
            }


            private bool CanAddToCart()
            {
                return SelectedProduct != null && SelectedProduct.Stock > 0;
            }

            private void RemoveFromCart()
            {
                if (SelectedCartItem != null)
                {
                    SelectedCartItem.Product.Stock += SelectedCartItem.Quantity;
                    var itemName = SelectedCartItem.Product.Name;
                    CartItems.Remove(SelectedCartItem);
                    Console.WriteLine($"Удален из корзины: {itemName}");
                    OnPropertyChanged(nameof(CartItems));
                    SelectedCartItem = null; // Сбросить выбор
                }
                else
                {
                    Console.WriteLine("Ошибка: SelectedCartItem is null");
                }
            }

            private void AddToCart()
            {  if (SelectedProduct != null && SelectedProduct.Stock > 0)
                {
                    var existingItem = CartItems.FirstOrDefault(c => c.Product.Id == SelectedProduct.Id);
                    if (existingItem == null)
                    {
                        CartItems.Add(new CartItem { Product = SelectedProduct, Quantity = 1 });
                        SelectedProduct.Stock--;
                        Console.WriteLine($"Добавлен в корзину: {SelectedProduct.Name}, Кол-во: 1");
                    }
                    else
                    {
                        if (existingItem.Quantity < existingItem.Product.Stock)
                        {
                            existingItem.Quantity++;
                            Console.WriteLine($"Увеличено кол-во в корзине: {SelectedProduct.Name}, Кол-во: {existingItem.Quantity}");
                        }
                    }
                    OnPropertyChanged(nameof(CartItems));
                }
            }


        


            private bool CanRemoveFromCart()
            {
                bool canRemove = SelectedCartItem != null;
                Console.WriteLine($"CanRemoveFromCart: {canRemove}");
                return canRemove;
            }



            private void AddOrder()
            {
                if (string.IsNullOrWhiteSpace(CustomerName) || !CartItems.Any())
                {
                    MessageBox.Show("Введите имя и добавьте товары в корзину.");
                    return;
                }

                var order = new Order
                {
                    CustomerName = CustomerName,
                    OrderDate = DateTime.Now,
                    Items = CartItems.Select(c => new OrderItem
                    {
                        ProductId = c.Product.Id,
                        Product = c.Product,
                        Quantity = c.Quantity
                    }).ToList()
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно создан!");
                LoadOrders();
                LoadProducts();

                CartItems.Clear();
                CustomerName = "";
                OnPropertyChanged(nameof(CartItems));
            }



            private void DeleteOrder()
            {
                if (SelectedOrder != null)
                {
                    foreach( var item in SelectedOrder.Items)
                    {
                        var product =_context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            product.Stock += item.Quantity; // возвращаем товар
                        }
                    }
               
                    _context.Orders.Remove(SelectedOrder);
                    _context.SaveChanges();
                    LoadOrders();
                    LoadProducts();
                    SelectedOrderItems.Clear();
                }
            }

            public void ClearProductFields()
            {
                NewProductName = "";
                NewProductPrice = 0;
                NewProductStock = 0;
                SelectedCategory = null;
            }

            // INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string name = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
