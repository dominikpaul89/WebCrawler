using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler
{
     class Program
    {
        static async Task Main(string[] args)
        {
            string websiteUrl = "https://pja.edu.pl/";

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);

            string content = await response.Content.ReadAsStringAsync();

            //Adresy email / numery telefonow


            string pattern = @"(([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?( ([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?)+)";
            MatchCollection result = Regex.Matches(content,pattern);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}
