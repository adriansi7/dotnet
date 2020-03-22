using Ex2.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace Ex2.Helpers
{
    class Actions
    {
        private static FileStream stream;

        public static void AddStore()
        {
            Inputs.ReadStoreInput(out string name, out string city, out int carsNumber);
            Store store = new Store(name, city);

            for (int i = 0; i < carsNumber; i++)
            {
                Inputs.ReadCarInput(out string make, out string model, out int year, out decimal price);
                Car car = new Car(make, model, year, price);
                Inputs.ReadProducerInput(out string producerName, out int deliveryTime);
                Producer producer = new Producer(producerName, deliveryTime);
                car.Producer = producer;
                store.CarList.Add(car);
            }

            Program.stores.Add(store);

            SaveStores();

            Menu.DisplayResult("Store saved successfully!");
        }

        public static void AddCustomer()
        {
            Inputs.ReadCustomerInput(out string name);

            Customer customer = new Customer(name);

            Program.customers.Add(customer);

            SaveCustomers();

            Menu.DisplayResult("Customer saved successfully!");
        }

        private static void SaveStores()
        {
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(@"D:\Stores.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Program.stores);
            stream.Close();
        }

        private static void SaveCustomers()
        {
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(@"D:\Customers.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Program.customers);
            stream.Close();
        }

        public static void SaveOrders()
        {
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(@"D:\Orders.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Program.orders);
            stream.Close();
        }

        public static void LoadStores()
        {
            IFormatter formatter = new BinaryFormatter();

            stream = new FileStream(@"D:\Stores.txt", FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                Program.stores = (List<Store>)formatter.Deserialize(stream);
            }
            catch
            {
                Program.stores = new List<Store>();
            }

            stream.Close();
        }

        public static void LoadOrders()
        {
            IFormatter formatter = new BinaryFormatter();

            stream = new FileStream(@"D:\Orders.txt", FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                Program.orders = (List<Order>)formatter.Deserialize(stream);
            }
            catch
            {
                Program.orders = new List<Order>();
            }

            stream.Close();
        }

        public static void LoadCustomers()
        {
            IFormatter formatter = new BinaryFormatter();

            stream = new FileStream(@"D:\Customers.txt", FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                Program.customers = (List<Customer>)formatter.Deserialize(stream);
            }
            catch
            {
                Program.customers = new List<Customer>();
            }

            stream.Close();
        }

        public static void SelectStore()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu.StoreMenu();
            }
        }

        public static bool ShowCars(int storeNumber) 
        {
            if (Program.stores[storeNumber] == null) 
            {
                Menu.DisplayResult("Store does not exists.");
                return false;
            }

            Console.WriteLine(System.Environment.NewLine);

            for(int i = 1; i <= Program.stores[storeNumber].CarList.Count; i++) 
            {
                Console.WriteLine(i + ") " + Program.stores[storeNumber].CarList[i-1].Print());
            }

            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Enter the car you want to buy or q to go to the main menu:");

            string Choice = Console.ReadLine();

            if (Choice == "q") 
            {
                return false;
            }

            bool success = Int32.TryParse(Choice, out int choiceNumber);

            if (!success || choiceNumber > Program.stores[storeNumber].CarList.Count || choiceNumber < 1) 
            {
                Menu.DisplayResult("Invalid car number");
                return false;
            }

            bool buyCars = true;

            while (buyCars)
            {
                buyCars = Actions.BuyCar(storeNumber, choiceNumber - 1);
            }            

            return false;
        }

        public static bool BuyCar(int storeNumber, int carNumber) 
        {
            if (Program.customers.Count < 1) 
            {
                Menu.DisplayResult("There are no customers in the database");
                return false;
            }

            if (Program.stores[storeNumber] == null || Program.stores[storeNumber].CarList[carNumber] == null) 
            {
                Menu.DisplayResult("Invalid car selected");
                return false;
            }

            Console.WriteLine("Please enter a customer name:");
            string customerName = Console.ReadLine();
            var customer = Program.customers.Find(item => item.Name == customerName);

            if (customer == null) 
            {
                Menu.DisplayResult("Invalid customer selected");
                return false;
            }
            
                        
            Order newOrder = new Order(customer);
            newOrder.AddToCart(Program.stores[storeNumber].CarList[carNumber]);
            
            Menu.DisplayResult(newOrder.Checkout());

            return false;
        }

        public static void ShowOrders() 
        {
            if (Program.orders.Count < 1) 
            {
                Menu.DisplayResult("There are no orders in the database");
                return;
            }

            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("ID|Customer|Items Count|Total Cost|Delivery Date|Status");

            for (int i = 1; i <= Program.orders.Count; i++)
            {
                Console.WriteLine(i + ") " + Program.orders[i - 1].Print());
            }

            Menu.DisplayResult("");
            return;
        }

        public static void CancelOrder() 
        {
            if (Program.orders.Count < 1)
            {
                Menu.DisplayResult("There are no orders in the database");
                return;
            }

            Console.WriteLine("Select an order to cancel or q to quit");
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("ID|Customer|Items Count|Total Cost|Delivery Date|Status");

            for (int i = 1; i <= Program.orders.Count; i++) 
            {
                Console.WriteLine(i + ") " + Program.orders[i-1].Print());
            }

            string Choice = Console.ReadLine();

            if (Choice == "q")
            {
                return;
            }

            bool success = Int32.TryParse(Choice, out int choiceNumber);

            if (!success || choiceNumber > Program.orders.Count || choiceNumber < 1)
            {
                Menu.DisplayResult("Invalid order number");
                return;
            }

            Program.orders.RemoveAt(choiceNumber - 1);
            Actions.SaveOrders();

            Menu.DisplayResult("Order successfully canceled.");

        }
    }
}
