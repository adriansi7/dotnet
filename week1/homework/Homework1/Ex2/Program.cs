using System;
using System.Collections.Generic;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 3, 4, 5, 4, 3, 7, 9, 3};

            Dictionary<int, int> dict = new Dictionary<int, int>();

            int findingThreshold = numbers.Length / 2;

            bool numberFound = false;

            foreach (int x in numbers)
            {
                if (dict.ContainsKey(x))
                {
                    dict[x]++;
                }
                else
                {
                    dict[x] = 1;
                }

                if (dict[x] >= findingThreshold)
                {
                    Console.WriteLine("The found number is: {0}" + System.Environment.NewLine, x);
                    numberFound = true;
                }
            }

            if (numberFound == false)
            {
                Console.WriteLine("The number was not found" + System.Environment.NewLine);
            }
        }
    }
}
