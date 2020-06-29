using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_TMDB
{
    public static class MovieProcessing
    /// Wszystkie metody zwracające wartości mają znaleźc się tu
    {
        public static void MainInstance()
        {
            List<Movie> filmy = MoviesList.ListaFilmow;

            List<Movie> NajlepszeFilmy = MoviesList.BestMovies(filmy, 7, 10);

            foreach (Movie m in NajlepszeFilmy)
            {
                Console.WriteLine(m.Title.PadRight(60, ' ') + " " + m.Rating);
            }

            Console.WriteLine("Witaj w becie programu przetwarzającego Bazę filmów TMDB. Wpisz:");
            Console.WriteLine("Najlepsze filmy (Aby wyświetlić najlepsze filmy z wybranego przez ciebie okresu),");
            Console.WriteLine("Dochodowe filmy (Aby wyświetlić najbardziej dochodowe filmy z wybranego przez siebie okresu),");
            Console.WriteLine("Producenci (Aby wyświetlić Producentów, którzy zarobili najwięcej w wybranym przez ciebie okresie).");

            bool check = false;
            string answer = Console.ReadLine();

            Console.WriteLine("Wybierz okres jaki cię interesuje");
            Console.WriteLine("-może to być rok lub lata (xxxx). Zostaw pusty drugi rok, jeśli chcesz dane tylko z jednego roku");
            Console.Write("Podaj rok początkowy: ");
            string data1 = Console.ReadLine();
            DateTime startYear = new DateTime(int.Parse(data1), 01, 01);
            DateTime endYear = new DateTime(int.Parse(data1), 12, 31);
            Console.Write("Podaj rok końcowy (opcjonalnie): ");
            string data2 = Console.ReadLine();
            if (data2 != "")
            {
                endYear = new DateTime(int.Parse(data2), 12, 31);
            }

            Console.WriteLine("Wybierz, ile wyników chciałbyś wyświetlić (domyślnie 10): \n");
            int ammount = int.Parse(Console.ReadLine());


            switch (answer)
            {
                case "Najlepsze filmy":
                    break;
                case "Dochodowe filmy":
                    break;
                case "Producenci":
                    Console.WriteLine("Wybierz interesującą cię wytwórnię filmową");
                    break;
                default:
                    Console.WriteLine("Nie wybrałeś odpowiedniej komendy, spróbuj jeszcze raz");
                    check = true;
                    break;
            }



            List<Movie> DzienPremiery = MoviesList.YearsChoice(filmy, startYear, endYear);

            foreach (Movie m in DzienPremiery)
            {
                Console.WriteLine(m.Title.PadRight(60, ' ') + " " + m.Release.ToString("yyyy-MM-dd"));
            }

            //List<Movie> Producent = MoviesList.Producer("Weinstein Company, The");

            //foreach (Movie m in Producent)
            //{
            //    Console.WriteLine(m.Title);
            //}
        }
    }
}
