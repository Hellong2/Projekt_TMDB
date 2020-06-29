using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_TMDB
{
    public static class MovieProcessing

    {
        public static void MainInstance()
        {
            List<Movie> filmy = MoviesList.ListaFilmow;

            Console.WriteLine("Witaj w becie programu przetwarzającego Bazę filmów TMDB. Wpisz:");
            Console.WriteLine("Najlepsze filmy (Aby wyświetlić najlepsze filmy z wybranego przez ciebie okresu),");
            Console.WriteLine("Dochodowe filmy (Aby wyświetlić najbardziej dochodowe filmy z wybranego przez siebie okresu),");
            Console.WriteLine("Producenci (Aby obliczyć, ile dany producent zarobił netto w wybranym przez ciebie okresie na filmach w TMDB top 5000).");

            bool check = false;
            string answer = Console.ReadLine();

            Console.WriteLine("Wybierz okres jaki cię interesuje");
            Console.WriteLine("-może to być rok lub lata (xxxx). Zostaw pustą drugą linię, jeśli chcesz dane tylko z jednego roku");
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

            static int Ammount()
            {
                Console.Write("Wybierz, ile wyników chciałbyś wyświetlić (domyślnie 10): ");
                int ammount = 10;
                string tempAmmount = Console.ReadLine();
                if (tempAmmount != "")
                    ammount = int.Parse(tempAmmount);
                return ammount;
            }

            switch (answer)
            {
                case "Najlepsze filmy":
                    int ammount = Ammount();

                    List<Movie> NajlepszeFilmy = MoviesList.BestMovies(MoviesList.YearsChoice(filmy, startYear, endYear), ammount);

                    foreach (Movie m in NajlepszeFilmy)
                    {
                        Console.WriteLine(m.Title.PadRight(60, ' ') + " " + m.Rating);
                    }
                    break;
                case "Dochodowe filmy":
                    ammount = Ammount();

                    List<Movie> DochodoweFilmy = MoviesList.MostProfitableMovies(MoviesList.YearsChoice(filmy, startYear, endYear), ammount);

                    foreach(Movie m in DochodoweFilmy)
                    {
                        Console.WriteLine(m.Title.PadRight(60, ' ') + " " + m.Rating);
                    }
                    break;
                case "Producenci":
                    Console.Write("Wybierz interesującą cię wytwórnię filmową: ");
                    string wytwornia = Console.ReadLine();

                    decimal zyskNetto = MoviesList.TotalIncome(MoviesList.Producer(MoviesList.YearsChoice(filmy, startYear, endYear), wytwornia));
                    Console.WriteLine($"Wytwórnia filmowa {wytwornia} zarobiła w okresie ({startYear.ToString("yyyy-MM-dd")}) - ({endYear.ToString("yyyy-MM-dd")}) {string.Format("{0:N}", zyskNetto)} $.");

                    break;
                default:
                    Console.WriteLine("Nie wybrałeś odpowiedniej komendy");
                    check = true;
                    break;
            }
        }
    }
}
