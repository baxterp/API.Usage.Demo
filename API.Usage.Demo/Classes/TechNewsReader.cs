using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Usage.Demo.Classes
{
    public class TechNewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageURL { get; set; }
    }

    public class TechNewsResponse
    {
        public List<TechNewsItem>? TechNews { get; set; }
    }

    public class TechNewsReader
    {
        public async static Task<TechNewsResponse?> GetTechNews(string rapidApiKey)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://technology-news4.p.rapidapi.com/technews/0/0"),
                Headers =
                {
                    { "x-rapidapi-key", "03b95f15c1msh25adab3237d4b36p107fc2jsn8ca895c5ea85" },
                    { "x-rapidapi-host", "technology-news4.p.rapidapi.com" },
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

        public static TechNewsResponse Parse(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TechNewsResponse>(json, options) ?? new TechNewsResponse { TechNews = new() };
        }
    }
}