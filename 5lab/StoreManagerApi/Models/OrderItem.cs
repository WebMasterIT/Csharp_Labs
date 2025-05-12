using System.Text.Json.Serialization;

namespace StoreManagerApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }            // внешний ключ

        [System.Text.Json.Serialization.JsonIgnore]
        public Order? Order { get; set; }
    }

}
