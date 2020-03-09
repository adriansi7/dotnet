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

        static void CalculateBill()
        {
            /*
            Customer IDNO :1001
            Customer Name :James
            unit Consumed: 800
            Amount Charges @Rs. 2.00 per unit : 1600.00
            Surchage Amount : 240.00
            Net Amount Paid By the Customer : 1840.00
            */

            Bill bill = new Bill();
            int id = customer.GetId();
            string name = customer.GetName();
            double consumption = customer.GetConsumption();
            double rate = bill.GetRate(consumption);
            double charges = rate * consumption;
            double surcharge = bill.GetSurcharge(charges);
            double total = charges + surcharge;
            
            Console.WriteLine(System.Environment.NewLine + "Customer IDNO: {0}", id);
            Console.WriteLine(System.Environment.NewLine + "Customer Name: {0}", name);
            Console.WriteLine(System.Environment.NewLine + "unit Consumed: {0}", consumption);
            Console.WriteLine(System.Environment.NewLine + "Amount Charges @Rs. {0} per unit : {1}", rate, charges);
            Console.WriteLine(System.Environment.NewLine + "Surchage Amount: {0}", surcharge);
            Console.WriteLine(System.Environment.NewLine + "Net Amount Paid By the Customer: {0}", total);

        }
    }
}
