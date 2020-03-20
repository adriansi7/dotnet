using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer x = new Timer(3000);
            x.AlarmEvent += processEvent;
            x.Elapse();
        }

        static void processEvent(object sender, EventArgs e)
        {
            Console.WriteLine("I am processing the event.");            
        }
    }
}
