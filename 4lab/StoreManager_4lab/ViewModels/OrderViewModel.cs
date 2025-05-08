using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore; 
using StoreManager_4lab.Data;
using StoreManager_4lab.Models;  

namespace StoreManager_4lab.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private readonly StoreDbContext _context;
        private Order _selectedOrder;
        private string _customerName;

        public ObservableCollection<Order> Orders { get; } = new();
        public ObservableCollection<Product> AvailableProducts { get; } = new();
        public ObservableCollection<OrderItem> SelectedItems { get; } = new();

        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (SetProperty(ref _selectedOrder, value) && value != null)
                {
                    CustomerName = value.CustomerName;
                    SelectedItems.Clear();
                    foreach (var item in value.Items)
                        SelectedItems.Add(item);
                }
            }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand UpdateOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        public OrderViewModel()
        {
            _context = new StoreDbContext();
            _context.Database.EnsureCreated();

            LoadOrders();
            LoadAvailableProducts();

            AddOrderCommand = new RelayCommand(_ => AddOrder());
            UpdateOrderCommand = new RelayCommand(_ => UpdateOrder(), _ => SelectedOrder != null);
            DeleteOrderCommand = new RelayCommand(_ => DeleteOrder(), _ => SelectedOrder != null);
        }

        private void LoadOrders()
        {
            Orders.Clear();
            foreach (var order in _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product).ToList())
                Orders.Add(order);
        }

        private void LoadAvailableProducts()
        {
            AvailableProducts.Clear();
            foreach (var product in _context.Products.ToList())
                AvailableProducts.Add(product);
        }

        private void AddOrder()
        {
            if (string.IsNullOrWhiteSpace(CustomerName) || SelectedItems.Count == 0) return;

            var newOrder = new Order
            {
                CustomerName = CustomerName,
                OrderDate = DateTime.Now,
                Items = SelectedItems.Select(i => new OrderItem
                {
                    Product = i.Product,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            Orders.Add(newOrder);
        }

        private void UpdateOrder()
        {
            if (SelectedOrder == null) return;

            SelectedOrder.CustomerName = CustomerName;
            SelectedOrder.Items = SelectedItems.Select(i => new OrderItem
            {
                Product = i.Product,
                Quantity = i.Quantity
            }).ToList();

            _context.Orders.Update(SelectedOrder);
            _context.SaveChanges();
        }

        private void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                _context.Orders.Remove(SelectedOrder);
                _context.SaveChanges();
                Orders.Remove(SelectedOrder);
                SelectedOrder = null;
                SelectedItems.Clear();
                CustomerName = string.Empty;
            }
        }
    }
}
