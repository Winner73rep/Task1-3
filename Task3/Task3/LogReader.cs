using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class LogReader
    {
        public static List<string> ReadLogFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("windows-1251")))
            {
                List<string> logText = new List<string>();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    logText.Add(line);
                }

                return logText;
            }
        }
    }
}
