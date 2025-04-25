using System;

namespace Components_Classes
{
    public class GraphicsCard : Component
    {
      

        public int MemorySize { get; set; } // ГБ
        public string Chipset { get; set; }

        public GraphicsCard(string name, string manufacturer, decimal price, int memorySize, string chipset)
            : base(name, manufacturer, price)
        {
            MemorySize = memorySize;
            Chipset = chipset;
        }

     
        public virtual void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Память: {MemorySize} ГБ, Чипсет: {Chipset}");
        }

        public void ShowGraphicsInfo()
        {
            throw new NotImplementedException();
        }
    }
}
