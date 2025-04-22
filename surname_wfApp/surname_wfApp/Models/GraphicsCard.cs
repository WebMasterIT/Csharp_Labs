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

        public int MemorySize { get; set; } // Память в МБ

        public string Type { get; set; }

        public int Cores { get; set; }

        // Конструктор без параметров
        public GraphicsCard() { }
        public GraphicsCard(string name, string manufacturer, decimal price, int memorySize, string type, int cores)
            : base(name, manufacturer, price)
        {
            MemorySize = memorySize;
            Type = type;
            Cores = cores;
        }

        public override string ToString() => $"{base.ToString()} - {MemorySize} МБ";
    }
}
