using Ex4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Classes{

    class Car: IVehicle
    {
        public Guid Id { get; }
        public decimal Credit { get; set; }
        public CarType CarType { get; set; }

        public Car(CarType type, decimal credit)
        {
            Id = Guid.NewGuid();
            CarType = type;
            Credit = credit;
        }
    }
}
