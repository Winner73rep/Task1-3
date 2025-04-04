using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Cтандартизация лог-файлов...");

            while (true)
            {
                string filePath="";
                List<string> logText = new List<string>();

                while (logText.Count == 0)
                {
                    try
                    {
                        Console.WriteLine("Введите путь к файлу...");
                        filePath = Console.ReadLine();
                        logText = LogReader.ReadLogFile(filePath);
                    }
                    catch
                    {
                        Console.WriteLine( $"Файл не найден! {filePath}");
                    }
                }

                string dateNow = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string folder = filePath.Contains('\\') ? filePath.Substring(0, filePath.LastIndexOf('\\') + 1) : "";
                string resultPath = $"{folder}RESULT-{dateNow}.txt";
                string problemPath = $"{folder}PROBLEM-{dateNow}.txt";

                
                var parsedLogs = LogParser.ParseLogText(logText);

                LogWriter.WriteLogFile(resultPath, parsedLogs[0]);
                LogWriter.WriteLogFile(problemPath, parsedLogs[1]);

                Console.WriteLine("Лог-файл стандартизирован!");
            }  
        }
    }
}
