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

        // porównanie łańcucha po kompilacji i wzorcowego
        public static bool CzyMozeZamienic(string s1, string s2)
        {
            char[] s1tablica = s1.ToArray();
            char[] s2tablica = s2.ToArray();

            char pomocnik;
            for (int i = 0; i < s1tablica.Length - 1; i++)
            {
                while (s1tablica[i] != s2tablica[i])
                {
                    pomocnik = s1tablica[i];
                    s1tablica[i] = s2tablica[i];
                    int j = i + 1;
                    while (s2tablica[i] != s1tablica[j])
                    {
                        if (j < s1tablica.Length - 1)
                        {
                            j++;
                        }
                        break;
                    }
                    s1tablica[j] = pomocnik;
                }
            }
            // dwa łańcuchy po zmianach:
            string s1a = new string(s1tablica).Trim();
            string s2b = new string(s2tablica).Trim();
            Console.WriteLine(s1a);
            Console.WriteLine(s2b);
            if (s1a == s2b)
            {
                return true;
            }
            return false;
        }
    }
}
