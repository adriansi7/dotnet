using System;
using System.Collections.Generic;
using System.Text;
using HotelApp.Interfaces;

namespace HotelApp.Classes
{
    [Serializable]
    class Room : IRate, IRoom
    {
        private string name;
        private Rate rate;
        private int adults;
        private int children;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Rate Rate
        {
            get { return this.rate; }
            set { this.rate = value; }
        }

        public int Adults
        {
            get { return this.adults; }
            set { this.adults = value; }
        }

        public int Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public Rate GetPriceForDays(int numberOfDays)
        {
            return this.rate * numberOfDays;
        }

        public string Print()
        {
            string output = "Room Name:" + this.Name + System.Environment.NewLine;
            output += "Room Rate:" + this.Rate.Print() + System.Environment.NewLine;
            output += "Room Adults:" + this.Adults + System.Environment.NewLine;
            output += "Room Children:" + this.Children + System.Environment.NewLine;

            return output;
        }
    }
}
