using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Company> Companies { get; set; }
        //[Name("genres")]
        //public string Genre { get; set; }
        //[Name("keywords")]
        //public string Tag { get; set; }
        
    }
}
