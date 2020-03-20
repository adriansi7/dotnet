using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Classes
{
    class Car: IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car(string make, string model, int year, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Price = price;
        }

        public override string ToString() 
        {
            return "Car make " + this.Make + ", model " + this.Model + ", year " + this.Year + ", price " + this.Price;
        }
    }
}
