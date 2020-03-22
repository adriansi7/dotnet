using Ex3.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Interfaces
{
    interface IVehicle
    {
        public Producer Producer { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Print();
    }
}
