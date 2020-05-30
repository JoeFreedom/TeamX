using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConsoleFilesDirectories
{
    public static class ConsoleFunctions
    {
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

        public static void MoveDirectory(string path)
        {
            WriteLine("Specify the path to move the folder:");
            string folder = ReadLine();
            try
            {
                Directory.Move(path, folder);
                WriteLine("Folder moved complete");
            }
            catch (Exception)
            {
                WriteLine("Failed to move folder");
            }
        }

        public static void Copy(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                WriteLine("Source directory does not exist or could not be found: ");
            }
            else
            {
                WriteLine("Specify the full path to copy");
                string copyPath = ReadLine();
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!Directory.Exists(copyPath))
                {
                    Directory.CreateDirectory(copyPath);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(copyPath, file.Name);
                    file.CopyTo(temppath, false);
                }

                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(copyPath, subdir.Name);
                    Copy(subdir.FullName);
                }
            }
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
        }
    }
}
