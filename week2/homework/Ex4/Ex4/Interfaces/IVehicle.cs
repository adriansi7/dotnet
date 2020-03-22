using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Interfaces
{
    public enum CarType
    {
        Moto = 1,
        Normal = 2,
        Large = 3
    };

    interface IVehicle
    {
        public Guid Id { get; }
        public decimal Credit { get; set; }
        public CarType CarType { get; set; }
    }
}
