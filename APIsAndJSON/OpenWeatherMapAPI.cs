using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        private readonly HttpClient _client;
        public string _apiKey;

        public OpenWeatherMapAPI(HttpClient client, string apiKey)
        {
            _client = client;
            _apiKey = apiKey;
        }

        public async Task<double> GetTemperatureAsync(string city, string apiKey)
        {
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";
            var response = await _client.GetStringAsync(weatherURL);
            var weatherObject = JObject.Parse(response);
            return (double)weatherObject["main"]["temp"];
        }
    }
}
