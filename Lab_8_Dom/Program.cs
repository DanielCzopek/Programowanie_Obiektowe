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

                for (int i = 0; looped; i += 2)
                {
                    if (czyPierwsza(i) == true)
                    {
                        primeNumbers.Add(i);
                        //Console.WriteLine("Iteration1: " + i);

                    }
                }

                Console.WriteLine("Stopping");

            });

            ////////////////////////////
            /// 

            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Started");

                for (int i = 1; looped; i += 2)
                {
                    if (czyPierwsza(i) == true)
                    {
                        primeNumbers.Add(i);
                        //Console.WriteLine("Iteration2: " + i);

                    }
                }

                Console.WriteLine("Stopping");

            });
            thread1.Start();

            thread2.Start();

            Thread.Sleep(10000);

            looped = false;

            thread1.Join();

            thread2.Join();

            Console.WriteLine("Znaleziono " + primeNumbers.Count + " liczb pierwszych");



            static bool czyPierwsza(int j)
            {
                if (j < 2)
                {
                    return false;
                }
                if (j == 2)
                {
                    return true;
                }
                if (j % 2 == 0)
                {
                    return false;
                }
                for (int i = 3; i < j; i += 2)
                {
                    if (j % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            };


        }
    }
}





