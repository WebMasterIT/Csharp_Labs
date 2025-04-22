using System;


namespace Components_Classes
{ 
     public class Processor : Component
    {
        public int Cores { get; set; }
        public double Frequency { get; set; } // ГГц

        public Processor(string name, string manufacturer, decimal price, int cores, double frequency)
            : base(name, manufacturer, price)
        {
            Cores = cores;
            Frequency = frequency;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Ядер: {Cores}, Частота: {Frequency} ГГц");
        }

        public void ShowProcessorInfo()
        {
            throw new NotImplementedException();
        }
    }
}
