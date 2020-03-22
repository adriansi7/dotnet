using Ex3.Classes;
using Ex3.Helpers;
using Ex3.Logging;
using System;
using System.Collections.Generic;

namespace Ex3
{
    class Program
    {
        public static List<Store> stores;
        public static List<Customer> customers;
        public static List<Order> orders;
        public static ILogging logger;
        static void Main(string[] args)
        {
            Actions.LoadStores();
            Actions.LoadCustomers();
            Actions.LoadOrders();

            Console.WriteLine("Please choose a logging method: ");
            Console.WriteLine("1) File Logger");
            Console.WriteLine("2) Console Logger");

            string loggingMethod = Console.ReadLine();

            logger = LogHelper.getLogger(loggingMethod);

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu.MainMenu();
            }

        }
    }
}
