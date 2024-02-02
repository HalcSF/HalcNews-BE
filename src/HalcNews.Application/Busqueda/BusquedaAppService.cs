using HalcNews.ApiNews;
using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using HalcNews.News;
using HalcNews.Alertas;
using HalcNews.NewsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace HalcNews.Busqueda
{
    public class SearchAppService : HalcNewsAppService, ISearchAppService
    {
        private readonly IApiNewsAppService _IApiNewsAppService;
        private readonly INewsListAppService _INewsListAppService;
        private readonly INewAppService _INewAppService;
        private readonly IAlertAppService _IAlertAppService;
        public SearchAppService(IApiNewsAppService apiNewsAppService, INewsListAppService newsListAppService, INewAppService newAppService, IAlertAppService alertAppService)
        {
            _IApiNewsAppService = apiNewsAppService;
            _INewsListAppService = newsListAppService;
            _INewAppService = newAppService;
            _IAlertAppService = alertAppService;
        }

        public async Task<Search> SearchNews(string keyword)
        {
            var news = await _IApiNewsAppService.Search(keyword);

            return new Search
            {
                Keyword = keyword,
                News = news
            };
        }
        public async Task SaveSearch(NewsListDto newsList, Search search)
        {
            var newsResponse = search.News;

            foreach (NewDto newDto in newsResponse)
            {
                await _INewAppService.InsertNewAync(newDto);

                // Asociar la noticia 
                newsList.News.Add(newDto);
            }

            // Actualizar la lista en la base de datos después de agregar todas las noticias
            await _INewsListAppService.UpdateNewsListAync(newsList);
        }

        public async Task AddAlert(string keyword)
        {
            var newAlert = new AlertDto
            {
                Search = keyword,
                DateFound = DateTime.Now,
                isRead = false,
            };

            //var newAlertMapped = ObjectMapper.Map<AlertDto, Alert>(newAlert);

            // Inserta la nueva alerta en el repositorio
            await _IAlertAppService.InsertAlertAsync(newAlert);

        }

    }
}
