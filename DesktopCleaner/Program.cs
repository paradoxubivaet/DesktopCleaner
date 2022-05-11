using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesktopCleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Я чистильщик, работаю шесть лет без заработной платы. На ваш страх и риск.");

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] fileNames = Directory.GetFiles(desktopPath);

            Directory.CreateDirectory(desktopPath + @"\ImagesARK6");
            Directory.CreateDirectory(desktopPath + @"\BooksARK6");
            Directory.CreateDirectory(desktopPath + @"\TextFilesARK6");
            Directory.CreateDirectory(desktopPath + @"\DocumentsARK6");
            Directory.CreateDirectory(desktopPath + @"\OtherARK6");
            Directory.CreateDirectory(desktopPath + @"\ProgramsARK6");

            string[] imageFormats = new string[] { "bmp", "png", "bmp", "jpg" };
            string[] bookFormats = new string[] { "fb2", "pdf", "epub" };
            string[] documentFormats = new string[] { "docx", "xlsx", "doc" };
            string[] programFormats = new string[] { "exe", "lnk"};

            if (fileNames.Length != 0)
            {
                foreach (var file in fileNames)
                {
                    string[] fullPath = file.Split('\\');
                    var fileName = fullPath[fullPath.Length - 1];
                    var fileFormat = fileName.Split('.').Last();

                    // заменить IF'ы на что-то более мобильное, гибкое
                    if (imageFormats.Contains(fileFormat))
                    {
                        CopyAndDeleteFile(desktopPath, "ImagesARK6", fileName, file);
                    }
                    else if (bookFormats.Contains(fileFormat))
                    {
                        CopyAndDeleteFile(desktopPath, "BooksARK6", fileName, file);
                    }
                    else if (fileFormat == "txt")
                    {
                        CopyAndDeleteFile(desktopPath, "TextFilesARK6", fileName, file);
                    }
                    else if (documentFormats.Contains(fileFormat))
                    {
                        CopyAndDeleteFile(desktopPath, "DocumentsARK6", fileName, file);
                    }
                    else if (programFormats.Contains(fileFormat))
                    {
                        CopyAndDeleteFile(desktopPath, "ProgramsARK6", fileName, file);
                    }
                    else
                    {
                        CopyAndDeleteFile(desktopPath, "OtherARK6", fileName, file);
                    }
                }
            }

            Console.ReadLine(); 
        }

        static void CopyAndDeleteFile(string targetPlaceForClear, string folder, string fileName, string file) 
        {
            var newPath = $@"{targetPlaceForClear}\{folder}\{fileName}";
            File.Copy(file, newPath);
            if (File.Exists(newPath))
            {
                Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                File.Delete(file);
            }
        }
    }
}
