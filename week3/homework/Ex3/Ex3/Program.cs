using System;
using System.Collections.Generic;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 2, 3, 7, 9, 1 };

            Console.WriteLine("Sum: {0}", intList.Sum());
            Console.WriteLine("Product: {0}", intList.Product());
            Console.WriteLine("Min: {0}", intList.Min());
            Console.WriteLine("Max: {0}", intList.Max());
            Console.WriteLine("Average: {0}", intList.Average());
        }
    }
}
