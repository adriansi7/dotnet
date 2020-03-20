using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Interfaces
{
    interface IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
