using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FakeAutoTrader
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static Dictionary<string, List<decimal>> stockPrices = new Dictionary<string, List<decimal>>();
        static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            HashSet<string> symbols = new HashSet<string>();
            List<Task> tasks = new List<Task>();

            //Get list of all symbols to watch
            while (true)
            {
                Console.WriteLine("Enter the stock symbol in upper case and press ENTER once. When you are done entering all symbols, press ENTER twice.");
                string userSymbol = Console.ReadLine();

                if(userSymbol == "")
                {
                    break;
                }
                
                if(symbols.Add(userSymbol) == false)
                {
                    Console.WriteLine("Cannot enter same stock twice!");
                }
                
            }

            Console.WriteLine("Now getting price updates...");

            //For each symbol, create a task to get the data for that symbol
            foreach (string symbol in symbols)
            {
                tasks.Add(Task.Factory.StartNew(() => GetSymbolData(symbol)).Unwrap());
            }

            //Wait for the tasks to complete
            Task.WaitAll(tasks.ToArray());

        }

        static async Task GetSymbolData(string symbol)
        {
            while (true)
            {
                try
                {
                    //Get response
                    string apiURL = "https://finnhub.io/api/v1/quote?symbol=" + symbol + "&token=c2t8592ad3i9opcklg9g";
                    HttpResponseMessage response = await client.GetAsync(apiURL);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    //Get current price from response
                    Regex rx = new Regex(@"(?<={""c"":)[^,]+");
                    Match currentPrice = rx.Match(responseBody);

                    //If there is a match
                    if (currentPrice.Success)
                    {
                        //Convert to decimal for math operations
                        decimal parsedCurrentPrice = decimal.Parse(currentPrice.ToString());
                        Console.WriteLine("Stock: " + symbol);
                        Console.WriteLine("Current Price: " + parsedCurrentPrice);

                        //Lock
                        mutex.WaitOne();

                        //Check if the symbol is in the dictionary
                        if (stockPrices.ContainsKey(symbol))
                        {
                            //Add new parsed price to list of prices
                            stockPrices.GetValueOrDefault(symbol).Add(parsedCurrentPrice);

                            List<decimal> prices = stockPrices.GetValueOrDefault(symbol);
                            int priceCount = prices.Count;

                            //If there are more than 2 prices saved, median is calculable
                            if (priceCount > 2)
                            {
                                //First sort list in ascending order
                                prices.Sort();

                                decimal median = 0;

                                //If odd number list, middle is easily found
                                if (priceCount % 2 != 0)
                                {
                                    median = prices[priceCount / 2];
                                }

                                //if even number list, two middle numbers then divide 2
                                else
                                {
                                    decimal lowerMid = prices[(priceCount / 2) - 1];
                                    decimal upperMid = prices[priceCount / 2];

                                    median = (lowerMid + upperMid) / 2;
                                }

                                Console.WriteLine("Current Median for " + symbol + ": " + median);

                                //Compare current price to median price
                                if (parsedCurrentPrice < median)
                                {
                                    Console.WriteLine("BUY " + symbol + " now, current difference is " + (median - parsedCurrentPrice));
                                }
                                else if (parsedCurrentPrice > median)
                                {
                                    Console.WriteLine("SELL " + symbol + " now, current difference is " + (parsedCurrentPrice - median));
                                }
                                else
                                {
                                    Console.WriteLine("NO CHANGE in median for " + symbol + "!!");
                                }
                            }

                        }
                        //If symbol not in dictionary, add
                        else
                        {
                            stockPrices.Add(symbol, new List<decimal> { parsedCurrentPrice });
                        }

                        //Unlock
                        mutex.ReleaseMutex();
                        Console.WriteLine();
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }

                //Wait 20 sec between updates
                await Task.Delay(20000);
            }
        }
    }
}
