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
            // Sergey
        }

        public static void Copy(string path)
        {
            WriteLine("Write the name of the folder to copy:");
            string folder = ReadLine();
            path += folder;
            if (!Directory.Exists(folder))
            {
                Directory.Move(path, folder);
                WriteLine("Folder creation complete");
            }
            else
            {
                WriteLine("Failed to create folder");
            }
            // Joel
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
            WriteLine("Write the name of the folder to create:");
            string folder = ReadLine();
            path += folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                WriteLine("Folder creation complete");
            }
            else
            {
                WriteLine("Failed to create folder");
            }
        }
        public static string GoToContent(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            WriteLine("Specify the path to the desired directory:");
            string specifiedPath = ReadLine();
            if (Directory.Exists(specifiedPath))
            {
                DirectoryContent(specifiedPath);
                return specifiedPath;
            }
            else
            {
                WriteLine($"Directory {specifiedPath} is not found");
                return path;
            }
            // Sergey
        }
        public static string GoToNextContent(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            WriteLine("Write the name of the folder:");
            string folder = ReadLine();
            string tempPath = path;
            if (Directory.Exists(tempPath + folder))
            {
                path += $"{folder}\\";
                DirectoryContent(path);
                return path;
            }
            else
            {
                tempPath += folder;
                WriteLine($"Directory {tempPath} is not found");
                return path;
            }
            // Sergey
        }
    }
}
