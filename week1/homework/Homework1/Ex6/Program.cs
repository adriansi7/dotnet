using System;

namespace Ex6
{
    class Program
    {
        public static string inputString;
        static void Main(string[] args)
        {
            ReadInput();
            GetLastWordLen();
        }
        static void ReadInput()
        {
            Console.WriteLine("The string is:" + System.Environment.NewLine);
            inputString = Console.ReadLine();

        }

        static void GetLastWordLen()
        {
            int len = 0;
            inputString.Trim();
            string[] words = inputString.Split(' ');
            string lastWord = words[words.Length - 1];

            Console.WriteLine("Last word is {0} with a length of {1}: " + System.Environment.NewLine, lastWord, lastWord.Length);
        }
    }
}
