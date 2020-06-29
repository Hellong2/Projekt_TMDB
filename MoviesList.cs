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

        public static List<Movie> YearsChoice (List<Movie> list,DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                DateTime tempDate = startDate;
                startDate = endDate;
                endDate = tempDate;
            }
            return list.Where(p => p.Release >= startDate && p.Release <= endDate).ToList<Movie>();
        }

        public static List<Movie> BestMovies (List<Movie> list, int ammount, int grade = 0)
        {
            return list.Where(p => p.Rating >= grade && p.Votes > 500).
                OrderByDescending(p => p.Rating).Take(ammount).ToList<Movie>();
        }


        public static List<Movie> Producer(List<Movie> list, string producer)
        {
            return list.Where(p => p.Companies.Any(x => x.Name == producer)).ToList<Movie>();
        }

        public static decimal TotalIncome(List<Movie> list)
        {
            decimal totalRevenue = list.Sum(p => p.Revenue);
            decimal totalBudget = list.Sum(p => p.Budget);
            return totalRevenue - totalBudget;
        }

    }
}
