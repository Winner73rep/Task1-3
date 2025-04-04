using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task3
{
    public static class LogWriter
    {
        public static void WriteLogFile(string path, List<string> logText)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("windows-1251")))
            {
                foreach (string line in logText)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
