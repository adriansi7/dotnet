using System;

namespace Ex08
{
    class Program
    {
        public static Customer customer;

        static void Main(string[] args)
        {
            ReadInput();
            CalculateBill();

        }

        static void ReadInput()
        {
            Console.WriteLine(System.Environment.NewLine + "Customer id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(System.Environment.NewLine + "Customer name:");
            string name = Console.ReadLine();

            Console.WriteLine(System.Environment.NewLine + "Consumption:");
            double consumption = Convert.ToDouble(Console.ReadLine());

            Program.customer = new Customer(id, name, consumption);

        }

        static void CalculateBill() { 

        }
    }
}
