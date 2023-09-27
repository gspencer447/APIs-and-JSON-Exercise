using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System;

namespace APIsAndJSON
{
    public class Program
    {
            private const string ApiKey = "6ba521e04dcca23e89b903aa5087600d";
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            #region
            string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string kanyeURL = "https://api.kanye.rest/";

            for (var item = 0; item < 5; item++)
            {
                if (item % 2 == 0)
                {
                    var ronResponse = client.GetStringAsync(ronURL).Result;
                    JArray ronObject = JArray.Parse(ronResponse);
                    Console.WriteLine("Ron Swanson: " + ronObject[0]);
                }
                else
                {
                    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                    JObject kanyeObject = JObject.Parse(kanyeResponse);
                    Console.WriteLine("Kanye West: " + kanyeObject["quote"]);
                }
            }
            #endregion

            Console.WriteLine("Please enter the name of the city you with to display the weather for.");
            var userInput = Console.ReadLine();

            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={userInput}&appid={ApiKey}&units=imperial";

            try
            {
                var weatherResponse = client.GetStringAsync(weatherURL).Result;
                JObject weatherObject = JObject.Parse(weatherResponse);

                double temperature = (double)weatherObject["main"]["temp"];


                Console.WriteLine($"The current temperature in {userInput} is {temperature} degrees fahrenheit.");

            }
            catch (HttpRequestException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}
