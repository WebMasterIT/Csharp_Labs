using System;
using System.Runtime.InteropServices;

namespace Components_Classes
{
    public class RAM : GraphicsCard
    {
        public int Capacity { get; set; } // ГБ
        public int Speed { get; set; } // МГц

        public RAM(string name, string manufacturer, decimal price, int memorySize, string chipset, int capacity, int speed)
            : base(name, manufacturer, price, memorySize, chipset)
        {
            Capacity = capacity;
            Speed = speed; 
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Объем: {Capacity} ГБ, Скорость: {Speed} МГц");
        }
    }
}
