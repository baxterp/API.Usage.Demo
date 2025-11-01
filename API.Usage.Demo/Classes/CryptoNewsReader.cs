using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Usage.Demo.Classes
{
    public class CryptoNewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageURL { get; set; }
    }

    public class CryptoNewsResponse
    {
        public List<CryptoNewsItem>? CryptoNews { get; set; }
    }

    public class CryptoNewsReader
    {
        public async static Task<CryptoNewsResponse?> GetCryptoNews()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://cryptocurrency-news3.p.rapidapi.com/cryptonews/0/0"),
                Headers =
                {
                    { "x-rapidapi-key", "03b95f15c1msh25adab3237d4b36p107fc2jsn8ca895c5ea85" },
                    { "x-rapidapi-host", "cryptocurrency-news3.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result  = Parse(body);

                return result;
            }
        }

        public static CryptoNewsResponse Parse(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<CryptoNewsResponse>(json, options) ?? new CryptoNewsResponse { CryptoNews = new() };
        }
    }
}