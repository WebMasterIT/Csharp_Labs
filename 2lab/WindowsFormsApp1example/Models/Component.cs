using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace surname_wfApp.Models
{
    public class Component
    {

        private List<Component> components = new List<Component>();
 
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }

        // Конструктор по умолчанию  
        public Component() { }

        public Component(string name, string manufacturer, decimal price)
        {
            Name = name; // Устанавливаем название
            Manufacturer = manufacturer; // Устанавливаем производителя
            Price = price; // Устанавливаем цену
        }


    }

}


