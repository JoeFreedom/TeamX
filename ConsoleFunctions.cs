using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConsoleFilesDirectories
{
    public static class ConsoleFunctions
    {
        public static void ShowMenu(ref string path,ref bool end)
        {
            string menu = ReadLine();
            switch (menu)
            {
                case "Info":
                    MenuOption();
                    break;
                case "DiscInformation":
                    DiscInfo();
                    break;
                case "ShowDirCont":
                    ConsoleFunctions.DirectoryContent(path);
                    break;
                case "GoToSpecificDir":
                    ConsoleFunctions.GoToSpecificDirectory(ref path);
                    break;
                case "GoToNextDir":
                    ConsoleFunctions.GoToNextDirectory(ref path);
                    break;
                case "CreateFolder":
                    ConsoleFunctions.CreateFolder(path);
                    break;
                case "CopyDirectory":
                    ConsoleFunctions.CopyDirectory(path);
                    break;
                case "DeleteDirectory":
                    ConsoleFunctions.DeleteDirectory(path);
                    break;
                case "MoveDirectory":
                    ConsoleFunctions.MoveDirectory(path);
                    break;
                case "Exit":
                    end = true;
                    break;
                default:
                    WriteLine("Unknown command");
                    break;
            }
        }

        public static void MenuOption()
        {
            WriteLine("CHOOSE WHAT COMMAND YOU INTEND TO EXECUTE: ");
            WriteLine("-------------------------------------------");
            WriteLine("DiscInformation - shows Discs and necessary details about them");
            WriteLine("ShowDirCont - sees what directories and files are there in the folder you are in");
            WriteLine("GoToSpecificDir - goes to an exact or specific directory");
            WriteLine("GoToNextDir - skips to the next directory");
            WriteLine("CreateFolder - creates a new folder");
            WriteLine("CopyDirectory - copies a all contents in the directory you are in to another");
            WriteLine("DeleteDirectory - deletes the chosen directory");
            WriteLine("MoveDirectory - completely moves the directory you are in");
            WriteLine("Exit - exits programme");
        }

        public static void DiscInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    WriteLine($"{drive.Name} - {GetGB(drive.TotalSize)} GB - {GetGB(drive.AvailableFreeSpace)} GB");
                }
            }
        }

        static double GetGB(long bytes)
        {
            var result = (double)bytes / (1024 * 1024 * 1024);
            return Math.Round(result, 2);
        }

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

        public static void CopyDirectory(string path)
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
                    CopyDirectory(subdir.FullName);
                }
            }
        }

        public static void DeleteDirectory(string path)
        {
            WriteLine("Write the name of the folder:");
            string folder = ReadLine();
            path += $"{folder}\\";
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

        public static void CreateFolder(string path)
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
        
        public static string GoToSpecificDirectory(ref string path)
        {
            WriteLine("Specify the path to the desired directory:");
            string specifiedPath = ReadLine();
            if (Directory.Exists(specifiedPath))
            {
                path = specifiedPath;
                return path;
            }
            else
            {
                WriteLine($"Directory {specifiedPath} is not found");
                return path;
            }
        }
        
        public static string GoToNextDirectory(ref string path)
        {
            WriteLine("Write the name of the folder:");
            string folder = ReadLine();
            string tempPath = path;
            if (Directory.Exists(tempPath + folder))
            {
                path += $"{folder}\\";
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
