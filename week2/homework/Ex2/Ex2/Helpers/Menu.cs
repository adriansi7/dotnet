using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Helpers
{
    class Menu
    {
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add new store");
            Console.WriteLine("2) Add new customer");
            Console.WriteLine("3) Buy new car");
            Console.WriteLine("4) View orders");
            Console.WriteLine("5) Cancel orders");
            Console.WriteLine("6) Exit");
            Console.Write(System.Environment.NewLine + "Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Actions.AddStore();
                    return true;

                case "2":
                    Actions.AddCustomer();
                    return true;

                case "3":
                    Actions.SelectStore();
                    return true;

                case "4":
                    Actions.ShowOrders();
                    return true;

                case "5":
                    Actions.CancelOrder();
                    return true;

                case "6":
                    return false;

                default:
                    return true;
            }
        }

        public static bool StoreMenu()
        {
            Console.Clear();

            if (Program.stores.Count < 1) 
            {
                DisplayResult("There are no stores in the database");
                return false;
            }

            else 
            {
                Console.WriteLine("Select a store:");

                int i;

                for (i = 1; i <= Program.stores.Count; i++) 
                {
                    Console.WriteLine("{0}) {1} from {2}", i, Program.stores[i - 1].Name, Program.stores[i - 1].City);
                }                
                
                Console.WriteLine("{0}) Back to main menu", i);
                

                bool success = Int32.TryParse(Console.ReadLine(), out int storeNumber);

                if (!success)
                {
                    return true;
                }

                if (storeNumber == i)
                {
                    return false;
                }

                if (storeNumber < 1 || storeNumber > Program.stores.Count) 
                {
                    return true;
                }

                bool showCars = true;

                while (showCars)
                {
                    showCars = Actions.ShowCars(storeNumber - 1);
                }               

                return true;

            }
            
        }

        public static void DisplayResult(string message)
        {
            Console.WriteLine("{0}", message);
            Console.Write(System.Environment.NewLine + "Press Enter to continue");
            Console.ReadLine();
        }

    }
}
