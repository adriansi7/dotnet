using System;
using System.Globalization;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            intException();
            dateException();
        }

        static void intException()
        {
            Console.Write("Enter number: ");

            int number = Convert.ToInt32(Console.ReadLine());

            string message = "Please enter a number between 1 and 100";

            InvalidRangeException<int> intException = new InvalidRangeException<int>(1, 100, message);

            try
            {
                if (number < intException.Start || number > intException.End)
                {
                    throw intException;
                }
                else
                {
                    Console.WriteLine("The number is in the range!");
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error, the valid range is {0} - {1}", ex.Start, ex.End);
            }
        }

        static void dateException()
        {
            Console.Write("Enter a date (dd.MM.yyyy): ");

            CultureInfo culture = new CultureInfo("ro-RO");

            DateTime date = Convert.ToDateTime(Console.ReadLine(), culture);

            string message = "Please enter a date between 1.1.1980 and 31.12.2013";

            InvalidRangeException<DateTime> dateException = new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31), message);

            try
            {
                if (date < dateException.Start || date > dateException.End)
                {
                    throw dateException;
                }
                else
                {
                    Console.WriteLine("The date is in the range!");
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error, the valid range is {0} - {1}", ex.Start, ex.End);
            }
        }
    }
}
