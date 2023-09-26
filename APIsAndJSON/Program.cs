using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string kanyeURL = "https://api.kanye.rest/";
            string weatherURL = "https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={6ba521e04dcca23e89b903aa5087600d}&units=imperial";

            var weatherResponse = client.GetStringAsync(weatherURL);
            JObject weatherObject = JObject.(weatherResponse);

            Console.WriteLine("Please enter the name of the city you with to display the weather for.");
            var userInput = Console.ReadLine();

            Console.WriteLine($"The current temperature in {userInput} is {weatherObject} degrees fahrenheit.");


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

        }
    }
}
