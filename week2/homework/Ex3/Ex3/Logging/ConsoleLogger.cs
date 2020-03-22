using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Logging
{
    class ConsoleLogger : ILogging
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
