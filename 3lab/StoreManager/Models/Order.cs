namespace StoreManager.Models
{
    // Модель заказа, содержащая информацию о клиенте и товарах
    public class Order
    {
        // Уникальный идентификатор заказа
        public int Id { get; set; }

        // Список элементов заказа (товар + количество)
        public List<OrderItem> Items { get; set; }

        // Имя клиента
        public string CustomerName { get; set; }

        // Дата создания заказа
        public DateTime OrderDate { get; set; }

        // Общая сумма заказа, вычисляемая как сумма цен товаров умноженная на их количество
        public decimal TotalPrice => Items.Sum(item => item.Product.Price * item.Quantity);
         
        // Конструктор, инициализирующий пустой список товаров
        public Order()
        { 
        }
    }
}