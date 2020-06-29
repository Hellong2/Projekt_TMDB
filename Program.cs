using System;
using System.Collections.Generic;

namespace Projekt_TMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> filmy = MoviesList.ListaFilmow;


            //MovieProcessing.MainInstance();

            filmy = MoviesList.Producer(filmy, "Weinstein Company, The");

            Console.WriteLine(MoviesList.TotalIncome(filmy));

            Console.ReadKey();

        }
    }
}
