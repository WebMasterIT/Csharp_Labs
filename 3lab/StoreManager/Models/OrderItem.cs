namespace StoreManager.Models
{
    // Модель элемента заказа, связывающая товар и его количество
    public class OrderItem
    {
        public int Id { get; set; }

        // Ссылка на товар
        public Product Product { get; set; }

        // Количество единиц товара в заказе
        public int Quantity { get; set; }
    }
}