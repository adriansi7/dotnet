using Ex4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Classes
{
    class Settings
    {
        public static int Timeout { get; }

        public static Dictionary<CarType, int> Prices = new Dictionary<CarType, int>
        {
            [CarType.Moto] = 5,
            [CarType.Normal] = 10,
            [CarType.Large] = 15
        };
        public static int ParkingSpots { get; }
        public static int Fine { get; }
        static Settings()
        {
            Timeout = 5000;
            ParkingSpots = 3;
            Fine = 50;
        }
    }
}
