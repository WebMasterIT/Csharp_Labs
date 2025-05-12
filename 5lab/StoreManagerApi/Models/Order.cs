namespace StoreManagerApi.Models
{ 
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItem> Items { get; set; } = new(); // ← ВОТ ЭТО СВОЙСТВО ОБЯЗАТЕЛЬНО
         
    }

}
