using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex3.Logging
{
    class FileLogger : ILogging
    {
        private string path = @"D:\Ex3.txt";
        private StreamWriter sw;
        public void Write(string message)
        {
            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine(message);
            tw.Close();
        }
    }
}
