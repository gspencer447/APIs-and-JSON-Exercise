using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System;

namespace APIsAndJSON
{
    public class Program
    {
        public static string apiKey { get; private set; } = "6ba521e04dcca23e89b903aa5087600d";
        public static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();

            #region
            var fetchRonQuotes = new RonVSKanyeAPI.RonSwansonQuotes(client);
            var fetchKanyeQuotes = new RonVSKanyeAPI.KanyeWestQuotes(client);

            for (var item = 0; item < 10; item++)
            {
                if (item % 2 == 0)
                {
                    var ronQuote = await fetchRonQuotes.GetRonSwansonQuoteAsync();
                    Console.WriteLine("Ron Swanson: " + ronQuote);
                }
                else
                {
                    var kanyeQuote = await fetchKanyeQuotes.GetKanyeWestQuoteAsync();
                    Console.WriteLine("Kanye West: " + kanyeQuote);
                    Console.WriteLine();
                }
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine();
            var fetchWeather = new OpenWeatherMapAPI(client, apiKey);
            Console.WriteLine("Please enter the name of the city you wish to display the weather for:");
            var userInput = Console.ReadLine();

            try
            {
                var temperature = await fetchWeather.GetTemperatureAsync(userInput, apiKey);
                Console.WriteLine($"The current temperature in {userInput} is {temperature} degrees Fahrenheit.");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
