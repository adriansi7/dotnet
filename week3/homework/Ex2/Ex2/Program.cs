using System;
using System.Threading;
using System.Timers;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {

            Timer x = new Timer(1);
            x.AlarmEvent += processEvent;

            while (true)
            {
                x.Add(1);
                Thread.Sleep(3000);
            }
            
        }
        static void processEvent(object sender, EventArgs e)
        {
            Console.WriteLine("I am processing the event.");            
        }
    }
}
