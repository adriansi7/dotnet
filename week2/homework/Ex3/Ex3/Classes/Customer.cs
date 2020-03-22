using Ex3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Classes
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
