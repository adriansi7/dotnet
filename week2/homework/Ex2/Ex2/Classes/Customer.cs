using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Classes
{
    [Serializable]
    class Customer : IPerson
    {
        public string Name { get; set; }

        public Customer(string name) 
        {
            this.Name = name;
        }
    }

}
