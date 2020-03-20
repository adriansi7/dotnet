using System;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.Add(9);

            list[0] = 15;

            list.Remove(5);

            foreach (int x in list) 
            {
                Console.WriteLine(x);
            }

        }
    }
}
