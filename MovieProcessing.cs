using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_TMDB
{
    public static class MovieProcessing
    /// Wszystkie metody zwracające wartości mają znaleźc się tu
    {
        public static DateTime YearToDatetimeStart (string Year)
        {

            try
            {
                DateTime inputtedYear = new DateTime(int.Parse(Year), 01, 01);
                return inputtedYear;
            }
            catch
            {
                Console.WriteLine("To nie jest Rok!");
            }
                            
        }

    }
}
