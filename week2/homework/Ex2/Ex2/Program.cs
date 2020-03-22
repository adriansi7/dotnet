using Ex2.Classes;
using Ex2.Helpers;
using System;
using System.Collections.Generic;

namespace Ex2
{
    class Program
    {
        public static List<Store> stores;
        public static List<Customer> customers;
        public static List<Order> orders;
        static void Main(string[] args)
        {
            Actions.LoadStores();
            Actions.LoadCustomers();
            Actions.LoadOrders();

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu.MainMenu();
            }

        }
    }
}
