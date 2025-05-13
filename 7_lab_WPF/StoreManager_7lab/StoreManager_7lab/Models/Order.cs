using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager_7lab.Models
{
    public class Order
    {
        public string Username { get; set; } // Логин, к которому привязан заказ

        public int Id { get; set; } // Уникальный идентификатор заказа
        public string CustomerName { get; set; } // Имя клиента
        public DateTime OrderDate { get; set; } // Дата оформления
        public List<OrderItem> Items { get; set; } = new(); // Список позиций заказа

        public decimal TotalPrice => Items?.Sum(item => (item.Product?.Price ?? 0) * item.Quantity) ?? 0;

    }
} 
