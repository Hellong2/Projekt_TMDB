using System;
using System.Collections.Generic;

namespace Projekt_TMDB
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            List<MoviesList> filmy = MoviesList.GetMovies(@"E:\Develop\C#\TMDB\Projekt_TMDB\tmdb_5000_movies2.csv");

            List<MoviesList> DzienPremiery = MoviesList.MovieDate(new DateTime(2011, 05, 14));

            foreach (MoviesList m in DzienPremiery)
            {
                Console.WriteLine(m.Title);
            }


            Console.ReadKey();

        }
    }
}
