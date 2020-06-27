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


        //Summary
        //Rozdzielanie stringów Company (Genre, Tag raczej do wykomentowania, ale można kombinować z systemem rekomendacji) na osobny słownik, relacja klucz główny-klucz obcy z Filmem (wiele do wielu)

        //Dictionary<string, string> dictionary = new Dictionary<string, string>();
        //string[] items = input.TrimEnd(',').Split(',');
        //foreach (string item in items)
        //{
        //    string[] keyValue = item.Split('=');
        //    dictionary.Add(keyValue[0], keyValue[1]);
        //}
        public static List<Movie> GetMovies(string fileName)
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
        /// <summary>
        /// Czy _listaFilmow.AddRange(movies); jest potrzebne?
        /// </summary>
        public static List<Movie> ListaFilmow
        {
            get
            {
                if (_listaFilmow == null)
                {
                    _listaFilmow = new List<Movie>();
                    List<Movie> movies = MoviesList.GetMovies(@"E:\Develop\C#\TMDB\Projekt_TMDB\tmdb_5000_movies2.csv");
                    _listaFilmow.AddRange(movies);
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
        //Summary
        //Obliczanie zysku dla każdego filmu (income-budget)
        
        //public static decimal Profit(string company)
        //{
        //    List<MoviesList> filmy = All.Where(f )
        //    return Value;
        //}

        ///Po zakończonej migracji do SQL dekonstruktor!
        //public ~MoviesList()
        //{

        //}



}
}
