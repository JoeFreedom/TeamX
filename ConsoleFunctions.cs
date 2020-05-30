using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConsoleFilesDirectories
{
    public static class ConsoleFunctions
    {
        // достаточно показать содержимое каталога, скопировать, удалить и создать, перейти к нужному каталогу
        public static void DirectoryContent(string path)
        {
            if (Directory.Exists(path))
            {
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                WriteLine("Folders:");
                foreach (var dir in directories)
                {
                    WriteLine(dir);
                }

                WriteLine("Files:");
                foreach (var file in files)
                {
                    WriteLine(file);
                }
            } 
            else
            {
                WriteLine($"Directory {path} is not found");
            }
           
        }
        
        public static void CopyTwo(string path)
        {
            WriteLine("Write the name of the folder to copy:");
            string folder = ReadLine();
            path += folder;
           // Directory dirInfo = new Directory(path);
            if (!Directory.Exists(path))
            {
                Directory.Move(path, folder);
                WriteLine("Folder creation complete");
            }
            else
            {
                WriteLine("Failed to create folder");
            }
        }

       public static void CopyTwo(string oldPath, string newPath)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
                if (dirInfo.Exists && Directory.Exists(newPath) == false)
                {
                    dirInfo.MoveTo(newPath);
                }
            }
            catch(Exception)
            {

            }
            
            // Joe
        }

        public static void Delete(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                WriteLine("Directory deleted");
            }
            else
            {
                WriteLine($"Directory {path} is not found");
            }
            // Sergey
        }

        public static void Create(string path)
        {
            string subPath;
             try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                directoryInfo.CreateSubdirectory(subPath);
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        public static void GoToNextContent(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string folder = ReadLine();
            path += folder;
            if (Directory.Exists(path))
            {
                DirectoryContent(path);
            }
            else
            {
                path += folder;
                WriteLine($"Directory {path} is not found");
            }
            // Sergey
        }
    }
}
