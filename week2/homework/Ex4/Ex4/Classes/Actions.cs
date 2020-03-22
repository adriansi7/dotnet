using Ex4.Interfaces;
using System;


namespace Ex4.Classes
{
    class Actions
    {
        public static string CarCheckin()
        {
            if (Program.parking.getFreeSpots() < 1) 
            {
                return "Sorry, the parking is full";
            }

            Console.WriteLine("Enter car type (Moto = 1, Normal Vehicle = 2, Large Vehicle = 3):");

            var carType = Helper.validateOption(1, 3);

            Console.WriteLine("Enter the credit:");

            var carCredit = Helper.validateMoney();

            Car car = new Car((CarType)carType, carCredit);

            Program.parking.AddCar(car);

            return System.Environment.NewLine + "The car was successfully checked in.";
        }

        public static string CarCheckout()
        {
            var takenSpots = Program.parking.getTakenSpots();

            if (takenSpots == 0)
            {
                return "The parking is empty.";
            }

            Console.WriteLine("Enter the number of this car from 1 to {0}:", takenSpots);

            var carNumber = Helper.validateOption(1, takenSpots);

            if (Program.parking.CheckFine(carNumber))
            {
                Console.WriteLine("The selected car has a fine, do you want to pay it?");

                var i = Helper.validateYesOrNo();

                if (i == 0)
                {
                    return System.Environment.NewLine + "You can not checkout a car without paying the fine.";
                }
            }

            Program.parking.RemoveCar(carNumber);

            return System.Environment.NewLine +  "The car was removed.";
        }

        public static string ShowSpots()
        {
            int takenSpots = Program.parking.getTakenSpots();
            int freeSpots = Program.parking.getFreeSpots();

            return "The parking has a capacity of " + Settings.ParkingSpots + System.Environment.NewLine + "There are " + takenSpots + " taken spots and " + freeSpots + " free spots";
        }

        public static string ExtendParking()
        {
            var takenSpots = Program.parking.getTakenSpots();

            if (takenSpots == 0)
            {
                return "The parking is empty.";
            }

            Console.WriteLine("Enter the number of this car from 1 to {0}:", takenSpots);

            var carNumber = Helper.validateOption(1, takenSpots);

            Console.WriteLine("Enter the credit:");

            var carCredit = Helper.validateMoney();

            Program.parking.Charge(carNumber, carCredit);

            return System.Environment.NewLine + "The car's parking time was extended";
        }

        public static string ShowRevenue()
        {
            return "The current revenue is " + Program.parking.Revenue + " EUR";
        }
    }
}
