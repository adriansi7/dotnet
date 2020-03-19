using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using HotelApp.Interfaces;

namespace HotelApp.Classes
{

    [Serializable]
    class Hotel : IRate, IHotel
    {
        private string name;
        private string city;
        private List<Room> rooms;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public List<Room> Rooms
        {
            get { return this.rooms; }
            set { this.rooms = value; }
        }

        public Rate GetPriceForNumberOfRooms(int numberOfRooms)
        {
            Room cheapestRoom = this.FindCheapestRoom();

            return cheapestRoom.Rate * numberOfRooms;
        }

        public string Print()
        {
            string output = this.Name + " | " + this.City + System.Environment.NewLine;

            foreach (var room in this.Rooms)
            {
                output += room.Print() + System.Environment.NewLine;
            }

            return output;
        }

        private Room FindCheapestRoom()
        {
            int minPrice = Int32.MaxValue;
            
            Room cheapestRoom = this.Rooms[0];

            foreach (var room in this.Rooms)
            {
                if (minPrice > room.Rate.Amount) {
                    minPrice = room.Rate.Amount;
                    cheapestRoom = room;
                }
            }

            return cheapestRoom;
        }
    }
}
