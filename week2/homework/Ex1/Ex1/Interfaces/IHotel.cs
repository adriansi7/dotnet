using HotelApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.Interfaces
{
    interface IHotel
    {
        public Rate GetPriceForNumberOfRooms(int rooms);
    }
}
