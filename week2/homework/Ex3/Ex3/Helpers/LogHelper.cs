using Ex3.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Helpers
{
    class LogHelper
    {
        public static ILogging getLogger(string choice) 
        {
            switch (choice) 
            {
                case "1":
                    return new FileLogger();

                default:
                    return new ConsoleLogger();
            }
        }
    }
}
