using Ex4.Classes;
using System;

namespace Ex4
{
    class Program
    {
        public static Parking parking = new Parking();
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            bool showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                menu.ShowMenu();
                showMenu = menu.Action();
            }
        }
    }
}
