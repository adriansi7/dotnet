using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Helpers
{
    class Inputs
    {
        public static void ReadStoreInput(out string name, out string city, out int carsNumber)
        {
            Console.WriteLine("Store Name:");
            name = Console.ReadLine();

            Console.WriteLine("Store City:");
            city = Console.ReadLine();

            Console.WriteLine("Number of Cars:");
            carsNumber = Convert.ToInt32(Console.ReadLine());
        }

        public static void ReadCarInput(out string make, out string model, out int year, out decimal price)
        {
            Console.WriteLine("Make:");
            make = Console.ReadLine();

            Console.WriteLine("Model:");
            model = Console.ReadLine();

            Console.WriteLine("Year:");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Price:");
            price = Convert.ToDecimal(Console.ReadLine());
        }

        public static void ReadProducerInput(out string name, out int deliveryTime)
        {
            Console.WriteLine("Producer name:");
            name = Console.ReadLine();

            Console.WriteLine("Producer delivery time:");
            deliveryTime = Convert.ToInt32(Console.ReadLine());
        }

        public static void ReadCustomerInput(out string name)
        {
            Console.WriteLine("Customer Name:");
            name = Console.ReadLine();
        }

    }
}
