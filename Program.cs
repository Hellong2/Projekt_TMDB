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
            Console.WriteLine("Wpisz: Najlepsze filmy/Dochodowe filmy/Producenci: \n");
            string answer = Console.ReadLine();
            Console.WriteLine(@"Wybierz okres jaki cię interesuje
                                    -może to być rok lub lata (xxxx, xxxx)");
            string data1 = Console.ReadLine();


            DateTime data2 = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Wybierz, ile wyników chciałbyś wyświetlić (domyślnie 10): \n");
                //int quantity = TryParse()
            do
            {

                switch (answer)
                {
                    case "Najlepsze filmy":
                        
                        break;
                    case "Dochodowe filmy":
                        break;
                    case "Producenci":
                        Console.WriteLine("Wybierz interesującą cię wytwórnie filmową");
                        break;
                    default:
                        Console.WriteLine("Nie wybrałeś odpowiedniej komendy, spróbuj jeszcze raz");
                        check = true;
                        break;
                }
            } while (check == true);



            List<Movie> DzienPremiery = MoviesList.YearsChoice(new DateTime(2011, 05, 14));

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
