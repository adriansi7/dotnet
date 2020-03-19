using System;
using System.Collections.Generic;
using System.Text;
using HotelApp.Interfaces;

namespace HotelApp.Classes
{
    [Serializable]
    class Rate : IRate
    {
        private int amount;
        private string currency;

        public Rate(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public int Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public string Currency
        {
            get { return this.currency; }
            set { this.currency = value; }
        }

        public string Print()
        {
            string output = this.Amount + " " + this.Currency;
            return output;

        }

        public Rate Multiply(int days)
        {
            this.Amount = this.Amount * days;

            return this;
        }

        public static Rate operator *(Rate rate, int days)
        {
            return rate.Multiply(days);
        }
    }
}
