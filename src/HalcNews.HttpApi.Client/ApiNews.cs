using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HalcNews.News;
using HalcNews.ApiNews;

namespace HalcNews.ApiNews { 
public class NewsService
{
    private readonly HttpClient _httpClient;

    public NewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<NewsResponse> GetNewsAsync()
    {
        var apiKey = "1967620b6fd64daf89307eec6ece4a14";
        var apiUrl = $"https://newsapi.org/v2/top-headlines?apiKey={apiKey}";

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var newsResponse = JsonConvert.DeserializeObject<NewsResponse>(content);
            return newsResponse;
        }
        else
        {
            // No se pudieron encontrar datos
            throw new ApplicationException("No se pudieron obtener noticias desde NewsAPI.");
        }
    }
}
}