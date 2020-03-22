using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Interfaces
{
    interface IProducer
    {
        string Name { get; set; }
        public int DeliveryTime { get; set; }
        public string Print();  
    }
}
