using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace HalcNews.ApiNews
{
    public class HandlerApiNews
    {
        NewsApiClient newsApiClient;

        public HandlerApiNews()
        {
            newsApiClient = new NewsApiClient("1967620b6fd64daf89307eec6ece4a14");
        }

        public Task<string> GetNews(string? Search, int? NewsQuantity)
        {
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = Search ?? "news", //si no hay parámetro de entrada, se busca news, un filtro de noticias en gral
                SortBy = SortBys.Popularity,
                Language = Languages.ES, // ver lógica para implementar lenguaje del usuario
                PageSize = NewsQuantity ?? 20

            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                string jsonResult = JsonConvert.SerializeObject(articlesResponse);

                return Task.FromResult(jsonResult);
            }
            else
            {
                throw new ApplicationException("No se pudieron obtener noticias desde NewsAPI, error: " + articlesResponse.Status);
            }
        }
    }
}