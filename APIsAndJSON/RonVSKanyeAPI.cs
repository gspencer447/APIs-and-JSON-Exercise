using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public class RonSwansonQuotes
        {
            private const string RonSwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            private readonly HttpClient _client;

            public RonSwansonQuotes(HttpClient client)
            {
                _client = client;
            }

            public async Task<string> GetRonSwansonQuoteAsync()
            {
                var response = await _client.GetStringAsync(RonSwansonUrl);
                var quoteArray = JArray.Parse(response);
                return quoteArray[0].ToString();
            }
        }

        public class KanyeWestQuotes
        {
            private const string KanyeWestUrl = "https://api.kanye.rest/";

            private readonly HttpClient _client;

            public KanyeWestQuotes(HttpClient client)
            {
                _client = client;
            }

            public async Task<string> GetKanyeWestQuoteAsync()
            {
                var response = await _client.GetStringAsync(KanyeWestUrl);
                var quoteObject = JObject.Parse(response);
                return quoteObject["quote"].ToString();
            }
        }
    }

}

