using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surname_wfApp.Models
{
    [Serializable]
    public class Processor : Component
    {
        public double Frequency { get; set; } // Частота в ГГц
         

        public Processor(string name, string manufacturer, decimal price, double frequency)
            : base(name, manufacturer, price)
        {
            Frequency = frequency;
        }

        public override string ToString() => $"{base.ToString()} - {Frequency} ГГц";
    }
}
