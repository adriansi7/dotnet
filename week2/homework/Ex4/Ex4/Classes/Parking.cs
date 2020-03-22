using Ex4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Classes
{
    class Parking: IParking
    {
        public decimal Revenue { get; set; }
        public List<Car> cars;

        public Parking()
        {
            Revenue = 0;
            cars = new List<Car>(Settings.ParkingSpots);
            ParkingTimer timer = new ParkingTimer();
        }

        public void getMoney(Car car) 
        {
            Settings.Prices.TryGetValue(car.CarType, out var price);

            if (car.Credit < price)
            {
                price = Settings.Fine;
            }
            
            car.Credit -= price;
            Revenue += price;
        }

        public void AddCar(Car car) => cars.Add(car);

        public int getTakenSpots() => cars.Count;

        public int getFreeSpots() => Settings.ParkingSpots - getTakenSpots();

        public bool CheckFine(int carNumber) 
        {
            return cars[carNumber - 1].Credit < 0;
        }

        public void RemoveCar(int carNumber)
        {
            cars.RemoveAt(carNumber - 1);
        }

        public void Charge(int carNumber, decimal carCredit) 
        {
            cars[carNumber].Credit += carCredit;
        }
    }
}
