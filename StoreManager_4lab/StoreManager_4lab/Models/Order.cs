using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager_4lab.Models
{
    public class Order
    {
        public int Id { get; set; } // Уникальный идентификатор заказа
        public string CustomerName { get; set; } // Имя клиента
        public DateTime OrderDate { get; set; } // Дата оформления
        public List<OrderItem> Items { get; set; } = new(); // Список позиций заказа

        public decimal TotalPrice => Items.Sum(item => item.Product.Price * item.Quantity); // Общая сумма
    }
} 
