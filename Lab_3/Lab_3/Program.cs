using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "text-123";
            Print(a + "1");
            Print("2");
            Print("3");
        }
        public static void Print(string text)
        {
            Console.WriteLine("print: " + text);
        }
    }
}
