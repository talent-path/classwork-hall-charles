using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the URL you want to get.");
            string userInput = Console.ReadLine();

            try
            {
                HttpResponseMessage response = await client.GetAsync(userInput);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                await File.WriteAllTextAsync("../../../html.txt", responseBody);

                string pattern = @"(?<=href="")(http|https)[^""]+";

                Regex rx = new Regex(pattern);

                MatchCollection matches = rx.Matches(responseBody);

                Queue<string> queue = new Queue<string>();

                HashSet<string> urls = new HashSet<string>();

                queue.Enqueue(userInput);
                urls.Add(userInput);

                //Go to each page in queue
                //Get url's from that page and add new ones to queue
                int count = 0;
                while(queue.Count > 0 && count < 200)
                {
                    try
                    { 
                        HttpResponseMessage innerResponse = await client.GetAsync(queue.Dequeue());
                        innerResponse.EnsureSuccessStatusCode();
                        string innerResponseBody = await innerResponse.Content.ReadAsStringAsync();

                        matches = rx.Matches(innerResponseBody);

                        foreach (Match match in matches)
                        {
                            if (urls.Add(match.Value))
                            {
                                Console.WriteLine(match.Value);
                                queue.Enqueue(match.Value);
                                count++;
                            }
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("\nException Caught!");
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }

                Console.WriteLine("Count: " + count);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            
        }
    }
}
