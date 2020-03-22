using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Classes
{
    class Menu
    {
        private readonly string[] options = {
            "Please select an option." + System.Environment.NewLine,
            "1) Checkin a car",
            "2) Checkout a car",
            "3) Show parking spots",
            "4) Extend parking time",
            "5) Show revenue",
            "6) Exit"
        };

        public bool Action()
        {
            var flag = true;
            var value = Helper.validateOption(1, 7);
            string message = "";
            Console.Clear();

            switch (value)
            {
                case 1:
                    message = Actions.CarCheckin();
                    break;
                
                case 2:
                    message = Actions.CarCheckout();
                    break;
                
                case 3:
                    message = Actions.ShowSpots();
                    break;
                
                case 4:
                    message = Actions.ExtendParking();
                    break;
                
                case 5:
                    message = Actions.ShowRevenue();
                    break;
                
                case 6:
                default:
                    flag = false;
                    break;
            }

            if (flag)
            {
                DisplayResult(message);
            }

            return flag;
        }

        public void ShowMenu()
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine(System.Environment.NewLine);
        }

        public static void DisplayResult(string message = "") 
        {
            Console.WriteLine("{0}", message);
            Console.Write(System.Environment.NewLine + "Press Enter to continue");
            Console.ReadLine();
        }
    }
}
