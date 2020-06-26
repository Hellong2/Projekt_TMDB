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
        /// <summary>
        /// Pokombinować z klasą interface żeby przerzucić te dane, 
        /// </summary>
        [Name("original_title")]
        public string Title { get; set; }
        [Name("production_companies")]
        public string Company { get; set; }
        [Name("release_date")]
        public DateTime Release { get; set; }
        [Name("budget")]
        public decimal Budget { get; set; }
        [Name("revenue")]
        public decimal Revenue { get; set; }
        [Name("vote_average")]
        public decimal Rating { get; set; }
        [Name("vote_count")]
        public decimal Votes { get; set; }
        [Name("genres")]
        public string Genre { get; set; }
        [Name("keywords")]
        public string Tag { get; set; }
        //Summary
        //Rozdzielanie stringów Company, Genre, Tag na osobne słowniki, relacja klucz główny-klucz obcy z Filmem

        //Dictionary<string, string> dictionary = new Dictionary<string, string>();
        //string[] items = input.TrimEnd(',').Split(',');
        //foreach (string item in items)
        //{
        //    string[] keyValue = item.Split('=');
        //    dictionary.Add(keyValue[0], keyValue[1]);
        //}
        public static List<MoviesList> GetMovies(string fileName)
        {
            List<MoviesList> returnValue = new List<MoviesList>();
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.Delimiter = ",";
                        var options = new TypeConverterOptions { Formats = new[] { "yyyy-MM-dd" } };
                        csv.Configuration.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                        returnValue = csv.GetRecords<MoviesList>().ToList();
                    }
                }
            }
            return returnValue;
        }
        private static List<MoviesList> _listaFilmow;
        public static List<MoviesList> ListaFilmow
        {
            get
            {
                if (_listaFilmow == null)
                {
                    _listaFilmow = new List<MoviesList>();
                    List<MoviesList> movies = MoviesList.GetMovies(@"E:\Develop\C#\TMDB\Projekt_TMDB\tmdb_5000_movies2.csv");
                    _listaFilmow.AddRange(movies);
                }
                return _listaFilmow;
            }
        }
        
        public static List<MoviesList> MovieDate(DateTime date)
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
