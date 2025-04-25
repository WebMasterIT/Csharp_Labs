using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surname_wfApp.Models
{
    // Базовый класс для всех компонентов
    [Serializable] 
    public class GraphicsCard : Component
    {

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int MemorySize { get; set; } // Объем памяти (МБ)
        public string Type { get; set; } // Тип видеопамяти (GDDR5, GDDR6 и т. д.)
        public int BusWidth { get; set; } // Разрядность шины (бит)

        public GraphicsCard() { }

    }
}
