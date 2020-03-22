using Ex4.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Interfaces
{
    interface IParking
    {
        public decimal Revenue { get; set; }
        public void getMoney(Car car);
        public void AddCar(Car car);
        public int getTakenSpots();
        public int getFreeSpots();
        public bool CheckFine(int carNumber);
        public void RemoveCar(int carNumber);
        public void Charge(int carNumber, decimal carCredit);
    }
}
