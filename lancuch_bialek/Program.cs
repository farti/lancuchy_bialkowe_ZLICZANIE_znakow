using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lancuch_bialek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            // wczytanie pliku
            string sWczytany = wczytajPlik("plik");

            //rozdzielenie pliku na dwa łańcuchy i usuniecie znakow specjalnych
            char separator = '\n';
            String[] substrings = sWczytany.Split(separator);
            string s1 = null;// lancuch  do zmiany i wzór
            string s2 = null;
            for (int i = 0; i < substrings.Length; i++)
            {
                if (i % 2 == 0)
                {
                    s1 += substrings[i].Trim();
                }
                else
                {
                    s2 += substrings[i].Trim();
                }
            }
            // wypisanie łańcuchów do porównania
            Console.WriteLine("string s1: " + s1);
            Console.WriteLine("string s2: " + s2);

            // Drukujemy rozwiązanie:
            if (CzyMozeZamienic(s1, s2))
            {
                Console.WriteLine("Jest OK");
            }
            else Console.WriteLine("Nie da rady zamienić łańcucha ");

            //pauza
            System.Console.ReadKey();
        }
        //***************************************************

        // wczytywanie pliku :
        public static string wczytajPlik(string param)
        {
            Console.WriteLine("Czy istnieje:   c:\\dane.txt ?  ");
            Console.Read();
            if (File.Exists(@"C:\dane.txt"))
            {
                param = File.ReadAllText(@"C:\dane.txt");
            }
            else
            {
                Console.WriteLine("Nie znalazłem pliku c:dane.txt. Naciśnij dowolny klawisz.");
                Console.Read();
            }
            return param;
        }

        // porównanie ilosci komkretnych znakow w s1 i s2
        public static bool CzyMozeZamienic(string s1, string s2)
        {
            var liczba = 'T' - 'A' + 1;
            var licznik1 = Enumerable.Repeat(0, liczba).ToList();
            var licznik2 = Enumerable.Repeat(0, liczba).ToList();
            //zliczmy litery dla s1
            foreach (var litera in s1) 
            {
                if (litera>='A' && litera <='T')
                {
                    licznik1[litera - 'A'] += 1;
                }
            }
            //zliczmy litery dla s2
            foreach (var litera in s2)
            {
                if (litera >= 'A' && litera <= 'T')
                {
                    licznik2[litera - 'A'] += 1;
                }
            }
            // porównujemy dwie listy do siebie , jesli ok zwracamy ture
            bool wynik = true;
            for (int i = 0; i < 20; i++)
            {
                if (licznik1[i] != licznik2[i])
                {
                    wynik= false;
                    break;
                }
            }
            return wynik;
        }
    }
}
