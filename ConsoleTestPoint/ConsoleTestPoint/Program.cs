using System;
using System.IO;

namespace ConsoleTestPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath="Databases/Core.db";

            Console.WriteLine(File.Exists(filePath));

            Console.ReadKey();
        }
    }
}
