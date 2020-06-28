using System;
using System.Collections.Generic;

namespace Projekt_TMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Witaj w becie programu przetwarzającego Bazę filmów TMDB. Możesz:
                                -Wyświetlić najlepsze filmy z wybranego przez ciebie okresu,
                                -Wyświetlić najbardziej dochodowe filmy z wybranego przez siebie okresu,
                                -Wyświetlić Producentów, którzy zarobili najwięcej ww wybranym przez ciebie okresie");

            bool check = false;
            do
            {
                Console.WriteLine("Wpisz: Najlepsze filmy/Dochodowe filmy/Producenci");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "Najlepsze filmy":
                        break;
                    case "Dochodowe filmy":
                        break;
                    case "Producenci":
                        break;
                    default:
                        Console.WriteLine("Nie wybrałeś odpowiedniej komendy, spróbuj jeszcze raz");
                        check = true;
                        break;
                }
            } while (check == true);



            List<Movie> DzienPremiery = MoviesList.MovieDate(new DateTime(2011, 05, 14));

            foreach (Movie m in DzienPremiery)
            {
                Console.WriteLine(m.Title);
            }

            //List<Movie> Producent = MoviesList.Producer("Weinstein Company, The");

            //foreach (Movie m in Producent)
            //{
            //    Console.WriteLine(m.Title);
            //}


            Console.ReadKey();

        }
    }
}
