using HalcNews.Estadisticas;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace HalcNews.ApiNews
{
    public class ApiNewsService : IApiNews
    {
        NewsApiClient newsApiClient;
        private readonly IStatsAppService _IStatsAppService;

        public ApiNewsService(IStatsAppService statsAppService)
        {
            newsApiClient = new NewsApiClient("a3be31d397de431ab9f8c58314c3f3b8");
            _IStatsAppService = statsAppService;
        }

        public async Task<ICollection<ArticleDto>> GetNewsAsync(string? Search)
        {
            ICollection<ArticleDto> responseList = new List<ArticleDto>();

            DateTime responseStartTime = DateTime.Now; //Hora de inicio de la solicitud a la API

            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = Search ?? "Apple", //si no hay parámetro de entrada, se busca Apple
                SortBy = SortBys.Popularity,
                Language = Languages.ES, // ver lógica para implementar lenguaje del usuario
                From = DateTime.Now.AddMonths(-1),
                PageSize = 5 // Para no pasarnos del límite de la API
            }) ;

            DateTime responseEndTime = DateTime.Now; //Hora de fin de la solicitud a la API

            TimeSpan responseTime = responseEndTime - responseStartTime; //Diferencia horaria entre la solicitud de la API, tiempo de respuesta

            if (articlesResponse.Status == Statuses.Ok)
            {
                articlesResponse.Articles.ForEach(t => responseList.Add(new ArticleDto
                {
                    Author = t.Author,
                    Title = t.Title,
                    Description = t.Description,
                    Url = t.Url,
                    PublishedAt = (DateTime)t.PublishedAt,
                    UrlToImage = t.UrlToImage,
                    Content = t.Content
                }));

                StatsDto stats = new StatsDto
                {
                    Date = DateTime.Now,
                    ResponseTime = responseTime.TotalMilliseconds,
                    TotalArticles = articlesResponse.Articles.Count,
                    ArticlesWithImages = articlesResponse.Articles.Count(t => !string.IsNullOrEmpty(t.UrlToImage)),
                    Search = Search //Si no hay parámetro de búsqueda, se asigna null
                };

                await _IStatsAppService.InsertStatsAsync(stats);

                return responseList;
            }
            else
            {
                throw new ApplicationException("No se pudieron obtener noticias desde NewsAPI, error: " + articlesResponse.Error.Code);
            }
        }
    }
}