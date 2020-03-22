using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Ex4.Classes
{
    class ParkingTimer
    {
        private Timer getMoneyTimer;
        
        public ParkingTimer() 
        {
            SetGetMoneyTimer();
        }

        public void SetGetMoneyTimer()
        {
            getMoneyTimer = new Timer(Settings.Timeout);
            getMoneyTimer.Elapsed += GetMoneyEvent;
            getMoneyTimer.AutoReset = true;
            getMoneyTimer.Enabled = true;
        }

        private void GetMoneyEvent(object sender, ElapsedEventArgs e)
        {
            foreach (var car in Program.parking.cars)
            {
                Program.parking.getMoney(car);
            }
        }
    }
}
