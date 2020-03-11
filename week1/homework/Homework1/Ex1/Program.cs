using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        static string inputString;
        static void Main(string[] args)
        {
            ReadInput();
            RemoveDuplicates(inputString);
        }

        static void ReadInput()
        {
            Console.WriteLine("The string is:" + System.Environment.NewLine);
            inputString = Console.ReadLine();

        }

        static void RemoveDuplicates(string input)
        {
            var letters = new HashSet<char>(input);

            foreach (char c in letters)
            {
                Console.Write(c);
            }
        }
    }
}
