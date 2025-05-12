using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager_7lab.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }        
        public Product? Product { get; set; }       

        public int Quantity { get; set; }
        public int OrderId { get; set; } 
    }
}
