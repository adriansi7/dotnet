using HotelApp.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Homework2
{
    class Program
    {
        private static FileStream stream;
        private static List<Hotel> hotels;
        static void Main(string[] args)
        {
            LoadHotels();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a hotel");
            Console.WriteLine("2) Remove a hotel");
            Console.WriteLine("3) Show hotels");
            Console.WriteLine("4) Find a room with a price lower than some value");
            Console.WriteLine("5) Exit");
            Console.Write(System.Environment.NewLine + "Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddHotel();
                    return true;

                case "2":
                    RemoveHotel();
                    return true;

                case "3":
                    ShowHotels();
                    return true;

                case "4":
                    SearchRoom();
                    return true;

                case "5":
                    return false;

                default:
                    return true;
            }
        }

        private static void AddHotel()
        {
            ReadHotelInput(out string HotelName, out string City);

            Hotel hotel = new Hotel();
            hotel.Name = HotelName;
            hotel.City = City;

            List<Room> rooms = new List<Room>();

            ReadRoomInput(ref rooms);

            hotel.Rooms = rooms;

            Program.hotels.Add(hotel);
            SaveHotels();

            DisplayResult("Hotel saved successfully!");
        }

        private static void RemoveHotel()
        {
            ShowHotels();

            if (Program.hotels.Count > 1)
            {
                Console.WriteLine("Enter hotel number to remove:");
                int hotelNumber = Convert.ToInt32(Console.ReadLine());

                try
                {
                    Program.hotels.RemoveAt((hotelNumber - 1));
                }
                catch (Exception e)
                {
                    DisplayResult(e.ToString());
                    return;
                }

                DisplayResult("Hotel with index " + hotelNumber + " successfully removed");
            }

        }

        private static void ReadHotelInput(out string HotelName, out string City)
        {
            Console.WriteLine("Hotel Name:");
            HotelName = Console.ReadLine();

            Console.WriteLine("Hotel City:");
            City = Console.ReadLine();
        }

        private static void ReadRoomInput(ref List<Room> rooms)
        {
            Console.WriteLine("Hotel Rooms:");
            int roomsNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= roomsNumber; i++)
            {
                Console.WriteLine("Room{0} Name:", i);
                string RoomName = Console.ReadLine();

                Console.WriteLine("Room{0} Rate Amount:", i);
                int Amount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Room{0} Rate Currency:", i);
                string Currency = Console.ReadLine();

                Console.WriteLine("Room{0} Adults:", i);
                int Adults = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Room{0} Children:", i);
                int Children = Convert.ToInt32(Console.ReadLine());

                Room room = new Room();
                room.Name = RoomName;

                Rate rate = new Rate(Amount, Currency);

                room.Rate = rate;
                room.Adults = Adults;
                room.Children = Children;

                rooms.Add(room);

            }
        }

        private static void LoadHotels()
        {
            IFormatter formatter = new BinaryFormatter();

            stream = new FileStream(@"D:\Hotels.txt", FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                Program.hotels = (List<Hotel>)formatter.Deserialize(stream);
            }
            catch
            {
                Program.hotels = new List<Hotel>();
            }

            stream.Close();
        }
        private static void SaveHotels()
        {
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(@"D:\Hotels.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Program.hotels);
            stream.Close();
        }

        private static void ShowHotels()
        {
            if (Program.hotels.Count < 1)
            {
                DisplayResult("There are no hotels saved in the database");
            }
            else
            {
                string showHotelsMessage = System.Environment.NewLine + "Hotel Name | City | Rooms Info" + System.Environment.NewLine;

                int i = 1;

                foreach (var hotel in Program.hotels)
                {
                    showHotelsMessage += i + ") " + hotel.Print();
                    i++;
                }

                DisplayResult(showHotelsMessage);
            }

        }

        private static void SearchRoom()
        {

            if (Program.hotels.Count < 1)
            {
                DisplayResult("There are no hotels to search for");
                return;
            }

            string output = "";

            Console.WriteLine("How many days?");
            int days = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is your budget?");
            int budget = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many rooms?");
            int numberOfRooms = Convert.ToInt32(Console.ReadLine());

            int resultsFound = 0;

            foreach (var hotel in Program.hotels)
            {             
                Rate hotelPrice = hotel.GetPriceForNumberOfRooms(numberOfRooms) * days;
                
                if (hotelPrice.Amount <= budget)
                {
                    output += "Hotel " + hotel.Name + " in " + hotel.City + " with a total price of " + hotelPrice.Amount + " " + hotelPrice.Currency + System.Environment.NewLine;
                    resultsFound++;
                }
            }

            if (resultsFound == 0) {
                output += "No rooms found for the search criteria";
            }


            DisplayResult(output);

        }

        private static void DisplayResult(string message)
        {
            Console.WriteLine("{0}", message);
            Console.Write(System.Environment.NewLine + "Press Enter to continue");
            Console.ReadLine();
        }
    }
}
