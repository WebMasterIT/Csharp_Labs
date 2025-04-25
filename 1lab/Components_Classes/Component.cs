using System;

namespace Components_Classes // Определяем пространство имен для организации кода
{
    public class Component // Определяем класс Component, представляющий комплектующее
    {
        private string Name { get; set; } // Свойство для хранения названия комплектующего
        public string Manufacturer { get;  private set; } // Свойство для хранения производителя
        public decimal Price { get; set; } // Свойство для хранения цены


        public string Model { get; } = "DefaultModel"; // Можно задать только в конструкторе или сразу

        // Конструктор класса, инициализирующий свойства
        public Component(string name, string manufacturer, decimal price)
        {
            Name = name; // Устанавливаем название
            Manufacturer = manufacturer; // Устанавливаем производителя
            Price = price; // Устанавливаем цену
        }

        // Виртуальный метод для отображения информации о комплектующем
        public virtual void DisplayInfo()
        {
            // Вывод информации о комплектующем в консоль
            Console.WriteLine($"Комплектующее: {Name}, Производитель: {Manufacturer}, Цена: {Price} руб.");
        }
        


    }
}
