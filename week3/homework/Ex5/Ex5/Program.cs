using System;

namespace Ex5
{
    class Program
    {
        static int[] savedNumbers = new int[10];

        static void Main(string[] args)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.Write("Enter number {0} in the range [{1}...{2}] : ", i, 1, 30);
                    int number = ReadNumber(1, 30);
                    saveNumber(number, i);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The given number is null");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("The given number is not integer");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The given number exceeds the integer limits.");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The given number is not in the desired range.");
                return;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Print();
        }

        static void saveNumber(int number, int position) 
        {
            if ((position - 1) > 0 && Program.savedNumbers[position - 2] > number) 
            {
                throw new Exception("The inequality is false");
            }

            Program.savedNumbers[position - 1] = number;
        }

        static void Print() 
        {
            string message = "1 < ";

            foreach(var number in Program.savedNumbers) 
            {
                message += number + " < ";
            }

            message += "30";

            Console.WriteLine(System.Environment.NewLine + message);
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end) 
            {
                throw new ArgumentOutOfRangeException();
            } 

            return number;
        }
    }
}
