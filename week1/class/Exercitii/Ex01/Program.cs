using System;

namespace Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            reverseLetters();
        }

        static void reverseLetters()
        {
            int lettersCount;

            Console.WriteLine("\nHow many letters?");

            lettersCount = Convert.ToInt32(Console.ReadLine());

            char[] letters = new char[lettersCount];

            for (int i = 0; i < lettersCount; i++)
            {
                Console.WriteLine("\nEnter letter {0}", i + 1);
                letters[i] = Console.ReadKey().KeyChar;
            }

            Array.Reverse(letters);

            Console.WriteLine("\nReversed array is {0}", string.Join(", ", letters));
        }
    }
}
