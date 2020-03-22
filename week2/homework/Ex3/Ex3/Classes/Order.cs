using Ex3.Helpers;
using Ex3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Classes
{
    [Serializable]
    class Order: IOrder
    {
        public Customer Customer { get; set; }
        public List<Car> CarList = new List<Car>();

        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Order(Customer customer)
        {
            this.Customer = customer;
        }

        public void AddToCart(Car car)
        {
            this.CarList.Add(car);
        }        
        
        public void RemoveFromCart(Car car)
        {
            this.CarList.Remove(car);
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (var car in this.CarList) 
            {
                total += car.Price;
            }

            return total;
        }

        public string Checkout()
        {
            string message = "You have successfully bought the following cars: " + System.Environment.NewLine;

            int maxDeliveryWeeks = 0;

            foreach (var car in this.CarList)
            {
                message += car.Print();

                if (car.Producer.DeliveryTime > maxDeliveryWeeks) 
                {
                    maxDeliveryWeeks = car.Producer.DeliveryTime;
                }
            }

            message += System.Environment.NewLine + "The total cost is " + this.GetTotal() + " EUR";

            this.Date = DateTime.Now;

            this.DeliveryDate = DateTime.Now.AddDays(7 * maxDeliveryWeeks);

            this.Save();

            message += System.Environment.NewLine + "The estimated delivery date is " + this.DeliveryDate.ToString("dd.MM.yyyy");

            return message;
        }

        public void Save()
        {
            Program.orders.Add(this);
            Actions.SaveOrders();
        }

        public string Print() 
        {
            string output = "";

            output += this.Customer.Name + "|" + this.CarList.Count.ToString() + "|" + this.GetTotal().ToString() + " EUR|" + this.DeliveryDate.ToString("dd.MM.yyyy");

            if (this.DeliveryDate < DateTime.Now)
            {
                output += "|Delivered";
            }
            else 
            {
                output += "|In Progress";
            }

            return output;
        }
    }    
}
