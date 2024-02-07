using HalcNews.ApiNews;
using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using HalcNews.News;
using HalcNews.Carpetas;
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
        private readonly IFolderAppService _IFolderAppService;
        public SearchAppService(IApiNewsAppService apiNewsAppService, INewsListAppService newsListAppService, INewAppService newAppService, IAlertAppService alertAppService, IFolderAppService folderAppService)
        {
            _IApiNewsAppService = apiNewsAppService;
            _INewsListAppService = newsListAppService;
            _INewAppService = newAppService;
            _IAlertAppService = alertAppService;
            _IFolderAppService = folderAppService;
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

        public async Task AddAlert(int folderId, string keyword)
        {

            var newAlert = new Alert
            {
                Search = keyword,
                CreationDate = DateTime.Now,
                isActive = true,
                FolderId = folderId,
                Notifications = new List<Notification>(),
            };

            var newAlertMapped = ObjectMapper.Map<Alert, AlertDto>(newAlert);

            // Inserta la nueva alerta en el repositorio
            await _IAlertAppService.InsertAlertAsync(newAlertMapped);

        }

        public async Task AddNewInFolder(int folderId, NewDto newE)
        {

            var folder = await _IFolderAppService.GetFolderAsync(folderId);
            folder.News.Add(newE);
            await _IFolderAppService.UpdateFolderAsync(folder);

        }

        public async Task AddNewListInFolder(int folderId, NewsListDto newList)
        {

            var folder = await _IFolderAppService.GetFolderAsync(folderId);
            folder.NewsLists.Add(newList);
            await _IFolderAppService.UpdateFolderAsync(folder);

        }


    }
}
