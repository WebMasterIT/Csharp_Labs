using System.Collections.ObjectModel;
using System.Windows.Input;
using StoreManager_7lab.Models;
using StoreManager_7lab.Commands;
using StoreManager_7lab.Services;
using System.Linq;
using System;

namespace StoreManager_7lab.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private readonly ApiService _api = new();

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
                        SelectedItems.Add(new OrderItem
                        {
                            ProductId = item.ProductId,
                            Product = item.Product,
                            Quantity = item.Quantity
                        });
                }
            }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        public OrderViewModel()
        {
            AddOrderCommand = new RelayCommand(async _ => await AddOrder());
            DeleteOrderCommand = new RelayCommand(async _ => await DeleteOrder(), _ => SelectedOrder != null);

            _ = LoadOrders();
            _ = LoadAvailableProducts();
        }

        private async Task LoadOrders()
        {
            Orders.Clear();
            var orders = await _api.GetOrdersAsync();
            foreach (var order in orders)
                Orders.Add(order);
        }

        private async Task LoadAvailableProducts()
        {
            AvailableProducts.Clear();
            var products = await _api.GetProductsAsync();
            foreach (var p in products)
                AvailableProducts.Add(p);
        }

        private async Task AddOrder()
        {
            if (string.IsNullOrWhiteSpace(CustomerName) || SelectedItems.Count == 0) return;

            var newOrder = new Order
            {
                CustomerName = CustomerName,
                OrderDate = DateTime.Now,
                Items = SelectedItems.Select(i => new OrderItem
                {
                    ProductId = i.Product.Id,
                    Quantity = i.Quantity
                }).ToList()
            };

            await _api.AddOrderAsync(newOrder);
            await LoadOrders();

            CustomerName = "";
            SelectedItems.Clear();
        }

        private async Task DeleteOrder()
        {
            if (SelectedOrder == null) return;

            await _api.DeleteOrderAsync(SelectedOrder.Id);
            Orders.Remove(SelectedOrder);
            SelectedOrder = null;
            SelectedItems.Clear();
            CustomerName = string.Empty;
        }
    }
}
