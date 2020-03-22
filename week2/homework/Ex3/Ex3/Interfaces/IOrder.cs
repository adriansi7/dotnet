using Ex3.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Interfaces
{
    interface IOrder
    {
        public Customer Customer { get; set; }
        public void AddToCart(Car car);        
        public void RemoveFromCart(Car car);
        public decimal GetTotal();
        public string Checkout();
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Print();

    }
}
