﻿using System;
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

        public async Task<string> GetNews(string? Search)
        {
            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = Search ?? "Apple", //si no hay parámetro de entrada, se busca news, un filtro de noticias en gral
                SortBy = SortBys.Popularity,
                Language = Languages.ES, // ver lógica para implementar lenguaje del usuario

            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                string jsonResult = JsonConvert.SerializeObject(articlesResponse);

                return jsonResult;
            }
            else
            {
                throw new ApplicationException("No se pudieron obtener noticias desde NewsAPI, error: " + articlesResponse.Status);
            }
        }
    }
}