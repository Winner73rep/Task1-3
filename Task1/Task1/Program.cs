using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                Console.WriteLine(Compressor.CompressText(line));
            }
        }
    }
}
