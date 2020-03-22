using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Classes
{
    [Serializable]
    class Producer : IProducer
    {
        public string Name { get; set; }
        public int DeliveryTime { get; set; }

        public Producer(string name, int deliveryTime) 
        {
            this.Name = name;
            this.DeliveryTime = deliveryTime;
        }

        public string Print() 
        {
            return this.Name + " with delivery time of " + this.DeliveryTime + " weeks";
        }
    }
}
