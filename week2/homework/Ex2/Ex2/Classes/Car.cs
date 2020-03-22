using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Classes
{
    [Serializable]
    class Car : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public Producer Producer { get; set; }

        public Car(string make, string model, int year, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Price = price;
        }

        public string Print()
        {
            return "Producer " + this.Producer.Print() + ", car make " + this.Make + ", model " + this.Model + ", year " + this.Year + ", price " + this.Price + " EUR";
        }
    }
}
