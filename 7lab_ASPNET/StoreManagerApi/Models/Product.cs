namespace StoreManagerApi.Models
{
    // Модель отражает структуру таблицы "Products" в базе данных
    public class Product
    {
        public int Id { get; set; }         // Первичный ключ (идентификатор товара)
        public string Name { get; set; }    // Название товара
        public decimal Price { get; set; }  // Цена товара
        public int Stock { get; set; }      // Количество на складе
        public string Category { get; set; }// Категория товара
    }

}
