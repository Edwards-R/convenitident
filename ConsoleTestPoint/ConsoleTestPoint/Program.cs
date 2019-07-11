using System;
using System.IO;

namespace ConsoleTestPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath="TextFile.txt";

            //Console.WriteLine(File.Exists(filePath));

            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Console.WriteLine(System.IO.Directory.GetParent());

            Console.ReadKey();
        }
    }
}
