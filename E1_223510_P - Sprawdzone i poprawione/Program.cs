using System;

namespace PD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Zadanie 1 ==="); // Zrobione poprawnie podczas egzaminu

            Console.WriteLine(P1(new int[] { 17, 20, -30, -11 })); // -30
            Console.WriteLine(P1(new int[] { 3, 6, 12, 5, 6 })); // 6
            Console.WriteLine(P1(new int[] { 1, 3, 5, 7, 9 })); // -0
            Console.WriteLine(P1(new int[] { 3, 8, 12, 5, 6, 15, 21, -4, -10 })); // -10

            Console.WriteLine("==== Zadanie 2 ==="); // Zrobione poprawnie podczas egzaminu

            Console.WriteLine(P2(30)); // 14
            Console.WriteLine(P2(12345)); // 9 
            Console.WriteLine(P2(7)); // 7
            Console.WriteLine(P2(9876)); // 9

            Console.WriteLine("==== Zadanie 3 ==="); // Zrobione poprawnie dla wartości dodatnich, w poleceniu było coś z ujemnymi więc finalnie może być zle

            Console.WriteLine(P3(184)); // 10111000  -> 3,
            Console.WriteLine(P3(2137)); // 100001011001 -> 4
            Console.WriteLine(P3(1024)); // 10000000000 -> 2
            Console.WriteLine(P3(213421412)); // 1100101110001000110101100100 -> 9
        }

        #region Zadanie 1

        static int P1(int[] liczby, int i = 0)
        {
            if (i >= liczby.Length)
                return 0;

            var liczba = liczby[i];

            if (liczby[i] % 2 != 0) // Tylko parzyste liczby
                liczba = 0;

            var najmniejszaZPozostalych = P1(liczby, i + 1);

            if (liczba == 0)
                return najmniejszaZPozostalych;

            if (najmniejszaZPozostalych == 0)
                return liczba;

            if (liczba < najmniejszaZPozostalych)
                return liczba;

            return najmniejszaZPozostalych;
        }

        #endregion

        #region Zadanie 2

        static uint P2(long liczba)
        {
            long najwiekszaCyfra = int.MinValue;

            while (liczba > 16)
            {
                var reszta = liczba % 16;

                if (najwiekszaCyfra < reszta)
                    najwiekszaCyfra = reszta;

                liczba = liczba / 16;
            }


            var ostatniaReszta = liczba % 16;

            if (ostatniaReszta > najwiekszaCyfra)
                najwiekszaCyfra = ostatniaReszta;

            return (uint)najwiekszaCyfra;
        }

        #endregion

        #region Zadanie 3

        static ushort P3(long dane)
        {
            ushort iloscSekwencji = 0;

            bool poprzedni1 = true;


            for (int i = 0; i < 64; i++)
            {
                if ((dane & 0b1) == 0b1) // Pierwszy z prawej rowny jeden
                {
                    poprzedni1 = true;
                }
                else
                {
                    if (poprzedni1) // Poprzedni rowny 1
                        iloscSekwencji += 1; // rozpoczecie sekwencji

                    poprzedni1 = false;
                }


                dane = dane >> 1; // Usuniecie sprawdzonego bitu;
            }

            return iloscSekwencji;
        }

        #endregion
    }
}