using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Collections;
using System.Collections.Generic;

namespace HalcNews.ApiNews
{
    public class ApiNewsService : IApiNews
    {
        NewsApiClient newsApiClient;

        public ApiNewsService()
        {
            newsApiClient = new NewsApiClient("1967620b6fd64daf89307eec6ece4a14"); 
        }

        public async Task<ICollection<ArticleDto>> GetNewsAsync(string? Search)
        {
            ICollection<ArticleDto> responseList = new List<ArticleDto>();

            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = Search ?? "Apple", //si no hay parámetro de entrada, se busca Apple
                SortBy = SortBys.Popularity,
                Language = Languages.ES, // ver lógica para implementar lenguaje del usuario
                From = DateTime.Now.AddMonths(-1)
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                articlesResponse.Articles.ForEach(t => responseList.Add(new ArticleDto
                {
                    Author = t.Author,
                    Title = t.Title,
                    Description = t.Description,
                    Url = t.Url,
                    PublishedAt = t.Url,
                    UrlToImage = t.UrlToImage,
                    Content = t.Content
                }));


                return responseList;
            }
            else
            {
                throw new ApplicationException("No se pudieron obtener noticias desde NewsAPI, error: " + articlesResponse.Status);
            }
        }
    }
}