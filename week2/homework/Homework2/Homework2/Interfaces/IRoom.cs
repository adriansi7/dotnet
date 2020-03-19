using System;
using System.Collections.Generic;
using System.Text;
using HotelApp.Classes;

namespace HotelApp.Interfaces
{
    interface IRoom
    {
        Rate GetPriceForDays(int numberOfDays);
    }
}
