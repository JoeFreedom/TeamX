using System;
using System.IO;

using static System.Console;
namespace ConsoleFilesDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            //Тестирование методов
            //Показать содержимое каталога:
            DriveInfo[] drives = DriveInfo.GetDrives();
            string path = @"C:\";
            ConsoleFunctions.DirectoryContent(path); //Done!

            //Удаление:
            path = @"C:\TestFolder";
            ConsoleFunctions.Delete(path); //Done!

            //Переход в следующий каталог:
            path = @"C:\";
            path = ConsoleFunctions.GoToNextContent(path); 
            WriteLine(path); //Done!

            //Создание каталога:
            path = @"C:\";
            ConsoleFunctions.Create(path); //Done!
        }
    }
}
