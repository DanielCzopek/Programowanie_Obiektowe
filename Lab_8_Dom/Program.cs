using System;
using System.Collections.Generic;
using System.Threading;
namespace Lab_8_Dom
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //W taki sposób działa na jednym wątku ideolo

            //HashSet<int> primeNumbers = new HashSet<int>();
            //bool looped = true;


            //Thread thread1 = new Thread(() =>
            //{
            //    Console.WriteLine("Started");

            //    for (int i = 1; looped; ++i)
            //    {
            //        if (czyPierwsza(i) == true)
            //        {
            //            primeNumbers.Add(i);
            //            Console.WriteLine("Iteration1: " + i);

            //        }
            //    }
            //    Console.WriteLine("Stopping");
            //});


            //thread1.Start();
            //Thread.Sleep(10000);
            //looped = false;
            //thread1.Join();

            //bool looped2 = true;

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
                        Console.WriteLine("Iteration1: " + i);

                    }
                }
                Console.WriteLine("Stopping");
            });

            bool looped2 = true;

            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Started");

                for (int i = 1; looped2; ++i)
                {
                    if (czyPierwsza(i) == true)
                    {
                        primeNumbers.Add(i);
                        Console.WriteLine("Iteration2: " + i);

                    }
                }
                Console.WriteLine("Stopping");
            });

            thread1.Start();
          Thread.Sleep(1000);
            looped = false;
            thread1.Join();
        
            thread2.Start();
            Thread.Sleep(1000);
            looped2 = false;
            thread2.Join();
        }
        


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



