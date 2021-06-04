using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FakeAutoTrader
{
    //As a user, I should be able to enter a list of stock symbols to watch
    //(just pressing enter to indicate I'm done with a blank line).

    //As a user, I should be able to see periodic updates to prices
    //(once a minute for each monitored stock).

    //As a user, whenever a stock crosses above the median price observed so far,
    //I should get a message to sell that stock.

    //As a user, whenever a stock crosses below the median price observed so far, I should get a message to buy that stock.
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            List<string> symbols = new List<string>();
            List<Task> tasks = new List<Task>();

            //Get list of all symbols to watch
            while (true)
            {
                Console.WriteLine("Enter the stock symbol and press ENTER once. When you are done entering all symbols, press ENTER twice.");
                string userSymbol = Console.ReadLine().ToUpper();
                if(userSymbol == "")
                {
                    break;
                }
                symbols.Add(userSymbol);
            }

            //For each symbol, create a task to get the data for that symbol
            foreach(string symbol in symbols)
            {
                tasks.Add(Task.Factory.StartNew(() => GetSymbolData(symbol)));
            }
             
            
        }

        static async Task GetSymbolData(string symbol)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://finnhub.io/api/v1/quote?symbol=" + symbol + "&token=c2t8592ad3i9opcklg9g");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
