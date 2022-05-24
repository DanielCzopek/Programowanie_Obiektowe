using System;
using System.Collections.Generic;
using System.Threading;
namespace Lab_8_Dom
{
    public class Program
    {

        public static void Main(string[] args)
        {
            HashSet<int> primeNumbers = new HashSet<int>();
            bool looped = true;
            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Started");

                for (int i = 1; looped; ++i)
                {
                    if (czyPierwsza(i) == true)
                    {
                        primeNumbers.Add(i);
                        Console.WriteLine("Iteration: " + i);

                    }
                }

                Console.WriteLine("Stopping");
            });

            thread1.Start();
            Thread.Sleep(10000);
            looped = false;
            thread1.Join();

            static bool czyPierwsza(int j)
            {
                for (int i = 2; i <= Math.Sqrt(j); i++)
                {
                    if (j % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}


