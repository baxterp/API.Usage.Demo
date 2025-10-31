using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Usage.Demo.Classes
{
    public class F1NewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageURL { get; set; }
    }

    public class F1NewsResponse
    {
        public List<F1NewsItem>? F1News { get; set; }
    }

    public class F1NewsReader
    {
        public async static Task<F1NewsResponse?> GetF1News()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://f1-news1.p.rapidapi.com/f1news/0/0"),
                Headers =
                {
                    { "x-rapidapi-key", "03b95f15c1msh25adab3237d4b36p107fc2jsn8ca895c5ea85" },
                    { "x-rapidapi-host", "f1-news1.p.rapidapi.com" },
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

        public static F1NewsResponse Parse(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<F1NewsResponse>(json, options) ?? new F1NewsResponse { F1News = new() };
        }
    }
}