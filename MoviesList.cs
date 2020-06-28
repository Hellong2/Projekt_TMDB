using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Projekt_TMDB
{
    public class MoviesList
    {
        private static List<Movie> GetMovies(string fileName)
        {
            List<Movie> returnValue = new List<Movie>();
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.Delimiter = ",";
                        var options = new TypeConverterOptions { Formats = new[] { "yyyy-MM-dd" } };
                        csv.Configuration.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                        returnValue = csv.GetRecords<Movie>().ToList();
                    }
                }
            }
            return returnValue;
        }
        private static List<Movie> _listaFilmow;
        public static List<Movie> ListaFilmow
        {
            get
            {
                if (_listaFilmow == null)
                {
                    _listaFilmow = new List<Movie>();
                    List<Movie> movies = MoviesList.GetMovies(@"E:\Develop\C#\TMDB\Projekt_TMDB\tmdb_5000_movies2.csv");
                    _listaFilmow.AddRange(movies);
                    foreach (Movie movie in _listaFilmow)
                    {
                        movie.DivideString();
                    }
                }
                return _listaFilmow;
            }
        }
        /// <summary>
        /// Do wywalenia, służy do testów
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Movie> YearsChoice (DateTime date)
        {
            return ListaFilmow.Where(p => p.Release == date).
                OrderBy(p => p.Title).ToList();
        }
        //public static List<Movie> YearsChoice (DateTime date1, DateTime date 2)
        //{

        //}


        //public static List<Movie> Producer(string producer)
        //{
        //    List<Movie> movies = new List<Movie>();
        //    foreach (Movie film in _listaFilmow)
        //    {

        //    }

        //}


    }
}
