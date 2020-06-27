using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projekt_TMDB
{
    public class Movie
    {
        [Name("original_title")]
        public string Title { get; set; }
        [Name("production_companies")]
        public string CompanyString { get; set; }
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
        //[Name("genres")]
        //public string Genre { get; set; }
        //[Name("keywords")]
        //public string Tag { get; set; }
        public List<Company> Companies { get; set; }

        public Movie()
        {
            Companies = new List<Company>();
        }
        static List<string> DivideJsonStrings(string dictionaries)
        {
            List<string> result = new List<string>();
            bool append = true;
            string dictionary = "";
            for (int i = 1; i <= dictionaries.Length - 2; i++)
            {
                if (dictionaries[i] == '{')
                {
                    append = true;
                }

                if (append)
                {
                    dictionary += dictionaries[i];
                }

                if (dictionaries[i] == '}')
                {
                    append = false;
                    result.Add(dictionary);
                    dictionary = "";
                }
            }
            return result;


        }
        public void DivideString()
        {
            List<string> companiesStrings = DivideJsonStrings(CompanyString);
            foreach (string jsonString in companiesStrings)
            {
                Companies.Add(JsonSerializer.Deserialize<Company>(jsonString));
            }
        }
    }
}
