using Ex3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Classes
{
    [Serializable]
    class Store: IStore
    {
        public string Name { get; set; }
        public List<Car> CarList { get; set; }
        public string City { get; set; }

        public Store(string name, string city) 
        {
            this.Name = name;
            this.City = city;
            this.CarList = new List<Car>();
        }
    }
}
