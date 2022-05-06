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

            string targetPlaceForClear = @"C:\Users\BlackBroke\Desktop";
            string[] fileNames = Directory.GetFiles(targetPlaceForClear);

            Directory.CreateDirectory(targetPlaceForClear+ @"\ImagesARK6");
            Directory.CreateDirectory(targetPlaceForClear+ @"\BooksARK6");
            Directory.CreateDirectory(targetPlaceForClear+ @"\TextFilesARK6");
            Directory.CreateDirectory(targetPlaceForClear+ @"\DocumentsARK6");
            Directory.CreateDirectory(targetPlaceForClear+ @"\OtherARK6");
            Directory.CreateDirectory(targetPlaceForClear+ @"\ProgramsARK6");

            string[] imageFormats = new string[] { "bmp", "png", "bmp", "jpg" };
            string[] bookFormats = new string[] { "fb2", "pdf", "epub" };
            string[] documentFormats = new string[] { "docx", "xlsx", "doc" };

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
                        var newPath = $@"{targetPlaceForClear}\ImagesARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                    else if (bookFormats.Contains(fileFormat))
                    {
                        var newPath = $@"{targetPlaceForClear}\BooksARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                    else if (fileFormat == "txt")
                    {
                        var newPath = $@"{targetPlaceForClear}\TextFilesARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                    else if (documentFormats.Contains(fileFormat))
                    {
                        var newPath = $@"{targetPlaceForClear}\DocumentsARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                    else if (fileFormat == "exe")
                    {
                        var newPath = $@"{targetPlaceForClear}\ProgramsARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                    else
                    {
                        var newPath = $@"{targetPlaceForClear}\OtherARK6\{fileName}";
                        File.Copy(file, newPath);
                        if (File.Exists(newPath))
                        {
                            Console.WriteLine($"Файл {fileName} успешно скопирован и будет удалён.");
                            File.Delete(file);
                        }
                    }
                }
            }

            Console.ReadLine(); 
        }
    }
}
