using System;
using System.Collections.Generic;

namespace Ex3
{
    class Program
    {
        static string inputString;
        static void Main(string[] args)
        {
            ReadInput();
            CountFreq();
        }


        static void ReadInput()
        {
            Console.WriteLine("The string is:" + System.Environment.NewLine);
            inputString = Console.ReadLine();

        }

        static void CountFreq()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            char[] arrayChar = inputString.ToCharArray();

            foreach (var x in arrayChar) {
                if (dict.ContainsKey(x))
                {
                    dict[x]++;
                }
                else {
                    dict[x] = 1;
                }
            }

            foreach (var x in dict) {
                Console.WriteLine("{0}: {1} times" + System.Environment.NewLine, x.Key, x.Value);
            }
        }
    }
}
