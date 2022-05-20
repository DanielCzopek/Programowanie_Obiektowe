using System;
using System.Threading;
namespace Lab_8_Dom
{
	
	{
		public class Program
		{
			public static void Main(string[] args)
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

				Thread thread = new Thread(() =>
				{
					for (int i = 1; i <= 10000; ++i)

					{

						if (czyPierwsza(i))
						{
							Console.WriteLine(i);
						}


						Thread.Sleep(1000); // Zatrzymuje wątek na 1000ms czyli 1s,
											// powoduje to że cały odpalając program treści w konsoli wyświetlają się stopniowo a nie wszystkie na raz
					}

				});



				thread.Start();

				//         Thread thread2 = new Thread(() =>
				//         {
				//             for (int i = 10001; i <= 20000; i++)
				//             {
				//		if (czyPierwsza(i))
				//                 Console.WriteLine(i);
				//                 Thread.Sleep(1000);
				//             }
				//         });

				//         thread2.Start();

				//Thread thread3 = new Thread(() =>
				//{
				//	for (int i = 20001; i <= 30000; i++)
				//	{
				//		if (czyPierwsza(i))
				//			Console.WriteLine("Interation2: " + i);
				//		Thread.Sleep(1000);
				//	}
				//});

				//thread3.Start();

				//Thread thread4 = new Thread(() =>
				//{
				//	for (int i = 30001; i <= 40000; i++)
				//	{
				//		if (czyPierwsza(i))
				//			Console.WriteLine("Interation2: " + i);
				//		Thread.Sleep(1000);
				//	}
				//});

				//thread4.Start();

				//Oba wątki wywołują się w tym samym czasie.

				// Thread.Join() usypia główny wątek do momętu aż utworzony wątek nie zostanie usunięty
			}
		}
	}

}
