using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NasaqData
{
    class Program
    {
        static void Main(string[] args)
        {
            //Group data by year, get standard deviation for
            // open, high, low, close
            //output should be a dictionary that maps from year to a list of
            //answers for that year
            //Could also make a class to hold the report for the year

            //Create list to store all the quotes
            List<DailyQuote> allQuotes = new List<DailyQuote>();

            //Read quotes from csv file and add to allQuotes
            using (StreamReader reader = new StreamReader("../../../HistoricalData_1622126572138.csv"))
            {
                //Skip first header line
                string headerLine = reader.ReadLine();
                string line = null;

                while((line = reader.ReadLine()) != null)
                {
                    DailyQuote quote = new DailyQuote(line);
                    allQuotes.Add(quote);
                }
            }

            //Group the quotes by year, save in GroupByYear dictionary
            var groupedByYear = GroupByYear(allQuotes);

            //Create report dictionary
            Dictionary<int, List<string>> report = new Dictionary<int, List<string>>();

            //Go through each year in groupedByYear dictionary
            foreach (int year in groupedByYear.Keys)
            {
                //Lists for each of the categories
                List<decimal> allClose = new List<decimal>();
                List<decimal> allOpen = new List<decimal>();
                List<decimal> allHigh = new List<decimal>();
                List<decimal> allLow = new List<decimal>();

                //Get all values for close/open/high/low and add to respective lists
                foreach (DailyQuote quote in groupedByYear[year])
                {
                    allClose.Add(quote.Close);
                    allOpen.Add(quote.Open);
                    allHigh.Add(quote.High);
                    allLow.Add(quote.Low);
                }

                //Calculate standard dev of the lists for this year
                decimal closeStdDev = CalculateStandardDeviation(allClose);
                decimal openStdDev = CalculateStandardDeviation(allOpen);
                decimal highStdDev = CalculateStandardDeviation(allHigh);
                decimal lowStdDev = CalculateStandardDeviation(allLow);

                //Create answers list
                List<string> answers = new List<string>();
                answers.Add(closeStdDev.ToString("#.####"));
                answers.Add(openStdDev.ToString("#.####"));
                answers.Add(highStdDev.ToString("#.####"));
                answers.Add(lowStdDev.ToString("#.####"));

                //Add year key and answers to report dictionary
                report.Add(year, answers);
            }

            Console.WriteLine("Year  |  Close  |  Open  |  High  |  Low");
            foreach(int year in report.Keys)
            {
                Console.WriteLine(year + "  | " + report[year][0] + " | " + report[year][1] + " | " + report[year][2] + " | " + report[year][3]);
            }
            

        }

        private static Dictionary<int, List<DailyQuote>> GroupByYear(List<DailyQuote> allQuotes)
        {
            Dictionary<int, List<DailyQuote>> toReturn = new Dictionary<int, List<DailyQuote>>();

            for (int i = 0; i < allQuotes.Count; i++)
            {
                if (toReturn.ContainsKey(allQuotes[i].Date.Year))
                {
                    toReturn[allQuotes[i].Date.Year].Add(allQuotes[i]);
                }
                else
                {
                    toReturn.Add(allQuotes[i].Date.Year, new List<DailyQuote> { allQuotes[i] });
                }
            }

            return toReturn;
        }

        private static decimal CalculateStandardDeviation(List<decimal> allDecimals)
        {
            decimal average = allDecimals.Average();
            decimal sumOfDifferencesSquared = allDecimals.Sum(d => (d - average) * (d - average));
            decimal total = allDecimals.Count() - 1;

            return SquareRoot(decimal.Divide(sumOfDifferencesSquared, total));
        }

        static decimal SquareRoot(decimal square)
        {
            if (square < 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 32; i++)
                root = (root + square / root) / 2;
            return root;
        }
    }
}
