﻿using CsvHelper;
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
        public static List<Movie> MovieDate(DateTime date)
        {
            return ListaFilmow.Where(p => p.Release == date).
                OrderBy(p => p.Title).ToList();
        }

        /// <summary>
        /// Nie działa, błąd, do rozwiązania
        /// </summary>
        /// <param name="producer"></param>
        /// <returns></returns>
        //public static List<Movie> Producer(string producer)
        //{
        //    return ListaFilmow.Select(p => p.Companies
        //               .Where(n => n.Name == producer)
        //               .ToList()).ToList();
        //}


}
}
