using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessDate date1 = new BusinessDate(2022, 10, 24);
            BusinessDate date2 = new BusinessDate(2022, 10, 24);

            if (date1 > date2)
            {
                Console.WriteLine(date1 + " > " + date2);
            }
            if (date1 < date2)
            {
                Console.WriteLine(date1 + " < " + date2);
            }

            if (date1 == date2)
            {
                Console.WriteLine(date1 + " == " + date2);
            }
            if (date1 != date2)
            {
                Console.WriteLine(date1 + " != " + date2);
            }
        }
    }
}
