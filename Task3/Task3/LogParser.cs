using System;
using System.Collections.Generic;

namespace Task3
{
    public static class LogParser
    {
        private delegate string Format(string line);
        public static List<List<string>> ParseLogText(List<string> logText)
        {
            Format format = GetFormat(logText[0]);
            List<string> formattedFile = new List<string>();
            List<string> problemFile = new List<string>();
            foreach (var line in logText)
            {
                try
                {
                    formattedFile.Add(format(line));
                }
                catch
                {
                    problemFile.Add(line);
                }
            }
            List<List<string>> formattedFiles = new List<List<string>> { formattedFile, problemFile };
            return formattedFiles;
        }
        private static Format GetFormat(string firstLine)
        {
            Format format;
            if (firstLine.Split('|').Length >= 4)
                return format = Format2;
            else
                return format = Format1;
        }

        private static string Format1 (string line)
        {
            try
            {
                var lineArray = line.Split(' ');
                DateTime date = Convert.ToDateTime(lineArray[0]);
                string time = lineArray[1];
                string logLvl = lineArray[2];
                string message = "";
                for (int i = 3; i < lineArray.Length; i++)
                {
                    message += $" {lineArray[i]}";
                }
                string formattedMessage = FormatLine(date, time, logLvl, message);
                return formattedMessage;
            }
            catch
            {
                throw;
            }
        }

        private static string Format2 (string line)
        {
            try
            {
                var lineArray = line.Split('|');
                string[] dateTime = lineArray[0].Split(' ');
                DateTime date = Convert.ToDateTime(dateTime[0]);
                string time = dateTime[1];
                string logLvl = lineArray[1];
                string call = lineArray[2];
                string message = lineArray[3];
                string formattedMessage = FormatLine(date, time, logLvl, message, call);
                return formattedMessage;
            }
            catch
            {
                throw;
            }
        }

        private static string FormatLine(DateTime date, string time, string logLvl, string message, string call = "DEFAULT")
        {
            string formattedData = date.ToString("dd-MM-yyyy");
            string formattedTime = time;
            string formattedLogLvl = "";

            switch (logLvl)
            {
                case "INFORMATION":
                    formattedLogLvl = "INFO";
                    break;
                case "WARNING":
                    formattedLogLvl = "WARN";
                    break;
                default:
                    formattedLogLvl = logLvl;
                    break;
            }

            string formattedCall = call;
            string formattedMessage = message;

            return $"{formattedData}\t{formattedTime}\t{formattedLogLvl}\t{formattedCall}\t{formattedMessage}";
        }
    }
}
