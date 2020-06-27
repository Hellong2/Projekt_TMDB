using System;
using System.Collections.Generic;

namespace Projekt_TMDB
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Movie> filmy = MoviesList.ListaFilmow;


            List<Movie> DzienPremiery = MoviesList.MovieDate(new DateTime(2011, 05, 14));

            foreach (Movie m in DzienPremiery)
            {
                Console.WriteLine(m.Title);
            }


            Console.ReadKey();

        }
    }
}
