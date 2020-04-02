using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\dotnet projects\\";

            string[] entries = Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories);

            string readFile;

            int lineSize;

            Console.WriteLine("Please enter a filename to read: ");
            readFile = Console.ReadLine();


            Console.WriteLine("How many lines would you like to read: ");
            lineSize = Convert.ToInt32(Console.ReadLine());

            int[] lineNumbers = new int[lineSize];

            for (int i = 0; i < lineSize; i++)
            {
                Console.WriteLine("Enter line {0}", i + 1);
                lineNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(lineNumbers);

            foreach (string res in entries)
            {
                Console.WriteLine(res);
            }

            Console.WriteLine("Press ENTER to read the requested file");
            Console.ReadKey();

            IEnumerable<string> lines;

            try
            {
                lines = File.ReadAllLines(readFile).Where(x => !string.IsNullOrWhiteSpace(x));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach(int lineNumber in lineNumbers)
            {
                if (lines.ElementAt(lineNumber) != null) 
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, lines.ElementAt(lineNumber));
                }
            }
        }
    }
}
