using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek = new Ulamek(1, 2);
            Ulamek ulamek2 = new Ulamek(3, 4);
            Ulamek ulamek3 = ulamek + ulamek2;
        }
    }
    interface IEquatable
    {

    }
    interface IComparable : IEquatable
    {

    }
    class Ulamek : IComparable



    {
        private int licznik { get; }

        private int mianownik { get; }

        public Ulamek()
        {

        }

        public Ulamek(int licznik, int mianownik)
        {

        }

        public Ulamek(Ulamek ulamek)
        {
            this.licznik = ulamek.licznik;
        }
        public override string ToString()
        {
            return "działa?";
        }
        public static Ulamek operator +(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik + b.licznik + b.mianownik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator -(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik - b.licznik + b.mianownik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator *(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.licznik, b.mianownik * a.mianownik);
        }
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            if (b.licznik == 0)
            {
                throw new DivideByZeroException();
            }
            return new Ulamek(a.licznik * b.mianownik, a.mianownik * b.licznik);
        }
        public static Ulamek operator (int licznik, int mianownik)
        {
            Math.Round(licznik / mianownik);
        }

    }
}
