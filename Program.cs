using System;
using System.IO;
using static System.Console;

namespace ConsoleFilesDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\";
            bool end = false;
            WriteLine("Input 'Info' to see the menu.");
            do
            {
                ConsoleFunctions.ShowMenu(ref path, ref end);
            } while (!end);
            ReadKey();
        }
    }
}
