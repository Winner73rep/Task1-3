using System;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            for (int i = 0; i < 6; i++)
            {
                Thread thread = new Thread(() => {
                    Random rand = new Random(i);
                    while (true)
                    {

                        if (rand.Next(1, 300) == 6)
                            ServerClass.AddToCount(1);
                        else
                        {
                            ServerClass.GetCount();
                        }
                    }
                });

                thread.Name = $"Клиент {i}";
                thread.Start();
            } 
        }
    }
}
