using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Classes
{
    class Helper
    {
        public static int validateOption(int start, int end)
        {
            int input;
            while (!(int.TryParse(Console.ReadLine(), out input) && (input >= start && input <= end)))
            {
                Console.WriteLine("Please select an option from {0} to {1}", start, end);
            }
            return input;
        }

        public static decimal validateMoney() 
        {
            decimal amount = 0;
            var input = Console.ReadLine();
            
            while (!decimal.TryParse(input, out amount))
            {
                Console.WriteLine("You need to type a valid amount. Please use the following format: 3.55");
                input = Console.ReadLine();
            }
            return amount;
        }

        public static int validateYesOrNo()
        {
            ConsoleKey input;

            Console.Write("Please choose your answer [y/n] ");

            do
            {
                input = Console.ReadKey(false).Key;
            }
            while (input != ConsoleKey.Y && input != ConsoleKey.N);

            return (input == ConsoleKey.Y) ? 1 : 0;
        }
    }
}
