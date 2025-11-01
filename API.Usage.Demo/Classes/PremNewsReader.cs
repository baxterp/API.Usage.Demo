using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Usage.Demo.Classes
{
    public class PremNewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageURL { get; set; }
    }

    public class PremNewsResponse
    {
        public List<PremNewsItem>? PremNews { get; set; }
    }

    public class PremNewsReader
    {
        public async static Task<PremNewsResponse?> GetPremNews(string rapidApiKey)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://premier-league-news3.p.rapidapi.com/premnews/0/0"),
                Headers =
                {
                    { "x-rapidapi-key", rapidApiKey },
                    { "x-rapidapi-host", "premier-league-news3.p.rapidapi.com" },
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

        public static PremNewsResponse Parse(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<PremNewsResponse>(json, options) ?? new PremNewsResponse { PremNews = new() };
        }
    }
}