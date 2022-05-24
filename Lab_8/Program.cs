using System;
using System.Threading;

namespace Lab_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 1; i <= 5; ++i)
                {
                    Console.WriteLine("Iteration1: " + i);
                    Thread.Sleep(1000); // Zatrzymuje wątek na 1000ms czyli 1s,
                                        // powoduje to że cały odpalając program treści w konsoli wyświetlają się stopniowo a nie wszystkie na raz
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 1; i <= 5; ++i)
                {
                    Console.WriteLine("Iteration2: " + i);
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
            thread2.Start();

            Thread.Sleep(1000);  // Opóźnia główny wątek programu o 1 sekunde

            //  usypia główny wątek do momętu aż utworzony wątek nie zostanie usunięty


            //Oba wątki wywołują się w tym samym czasie.
        }
    }
}
