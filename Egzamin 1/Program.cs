using System;

namespace PD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(P1(new int[] { 17, 20, -30, -11 })); // -30, chyba dziala :)))
            Console.WriteLine(P2(30)); // 14, chyba dziala, oby :0
            Console.WriteLine(P3(184)); // 3, wynik dobry, moze dziala haha
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
