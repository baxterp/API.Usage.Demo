using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Usage.Demo.Classes
{
    public class UKNewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageURL { get; set; }
    }

    public class UKNewsResponse
    {
        public List<UKNewsItem>? UKNews { get; set; }
    }

    public class UKNewsReader
    {
        public async static Task<UKNewsResponse?> GetUKNews(string rapidApiKey)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://uk-news1.p.rapidapi.com/uknews/0/0"),
                Headers =
                {
                    { "x-rapidapi-key", "03b95f15c1msh25adab3237d4b36p107fc2jsn8ca895c5ea85" },
                    { "x-rapidapi-host", "uk-news1.p.rapidapi.com" },
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

        public static UKNewsResponse Parse(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<UKNewsResponse>(json, options) ?? new UKNewsResponse { UKNews = new() };
        }
    }
}