using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager_4lab.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }         // 🔹 Внешний ключ
        public Product Product { get; set; }       // 🔹 Навигационное свойство

        public int Quantity { get; set; }
    }
}
