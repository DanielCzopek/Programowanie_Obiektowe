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
				for (int j = 1; j <= 10; ++j)

				{
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

					if (czyPierwsza(j))
					{
						Console.WriteLine("Iteration1: " + j);
					}
					Thread.Sleep(1000); // Zatrzymuje wątek na 1000ms czyli 1s,
										// powoduje to że cały odpalając program treści w konsoli wyświetlają się stopniowo a nie wszystkie na raz
				}
			});
			
			//Thread thread2 = new Thread(() =>
			//{
			//	for (int i = 1; i<= 5; i++)
   //             {
   //                 Console.WriteLine("Interation2: " + i);
			//		Thread.Sleep(1000);
   //             }
			//});
			
			//thread2.Start();
			
			thread.Start();
			

			//Oba wątki wywołują się w tym samym czasie.

			// Thread.Join() usypia główny wątek do momętu aż utworzony wątek nie zostanie usunięty
		}
	}
}
 