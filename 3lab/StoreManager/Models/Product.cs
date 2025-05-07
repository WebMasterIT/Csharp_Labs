namespace StoreManager.Models
{
    // Модель товара, представляющая продукт в магазине
    public class Product
    {
        // Уникальный идентификатор товара
        public int Id { get; set; }

        // Название товара
        public string Name { get; set; }

        // Цена товара
        public decimal Price { get; set; }

        // Количество товара на складе
        public int Stock { get; set; }

        public string Category { get; set; }
    }
}