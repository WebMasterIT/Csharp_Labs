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
        public int Cores { get; set; }

        public Processor () { }

        public Processor(string name, string manufacturer, decimal price, double frequency, int cores)
            : base(name, manufacturer, price)
        {
            Frequency = frequency;
            Cores = cores;  
        }
         
    }
}
