using System;

namespace Ex02
{
    class Program
    {
        public static int a;
        public static int b;
        public static char operation;
        public static float result;

        static void Main(string[] args)
        {
            readInput();

            try
            {
                Program.result = doOperation();
                printResult();
            }
            catch (System.InvalidOperationException e) {
                Console.WriteLine(System.Environment.NewLine + e);
            }            
        }

        static void readInput()
        {
            Console.WriteLine("First number is:" + System.Environment.NewLine);
            Program.a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Second number is:" + System.Environment.NewLine);
            Program.b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Operation is:" + System.Environment.NewLine);
            Program.operation = Console.ReadKey().KeyChar;

        }

        static float doOperation()
        {
            switch (Program.operation)
            {
                case '+':
                    return Program.a + Program.b;

                case '-':
                    return Program.a - Program.b;

                case '*':
                    return Program.a * Program.b;

                case '/':
                    return (float) Program.a / Program.b;

                default:
                    throw new System.InvalidOperationException(System.Environment.NewLine + "Operation is not defined");
            }
        }
        static void printResult()
        {
            Console.WriteLine(System.Environment.NewLine + "{0} {1} {2} = {3}", Program.a, Program.operation, Program.b, Program.result);
        }
    }
}
