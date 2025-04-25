using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surname_wfApp.Models
{ 

    namespace ComponentManager.Models
    {
        [Serializable]
        public class RAM : Component
        {
            public int Capacity { get; set; } // Объем в ГБ

            public bool isComplect {  get; set; }

              
            public RAM(string name, string manufacturer, decimal price, int capacity, bool iscomplect)
                : base(name, manufacturer, price)
            {
                Capacity = capacity;
            }

            public override string ToString() => $"{base.ToString()} - {Capacity} ГБ";
        }
    }

}
