using HalcNews.ApiNews;
using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using HalcNews.News;
using HalcNews.NewsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace HalcNews.Busqueda
{
    public class SearchAppService : HalcNewsAppService, ISearchAppService
    {
        private readonly IApiNewsAppService _IApiNewsAppService;
        private readonly ISearchAppService _ISearchAppService;
        private readonly INewsListAppService _INewsListAppService;
        private readonly INewAppService _INewAppService;
        public SearchAppService(IApiNewsAppService apiNewsAppService, ISearchAppService searchAppService, INewsListAppService newsListAppService, INewAppService newAppService)
        {
            _IApiNewsAppService = apiNewsAppService;
            _ISearchAppService = searchAppService;
            _INewsListAppService = newsListAppService;
            _INewAppService = newAppService;
        }

        public async Task<Search> SearchNews(string keyword)
        {
            var news = await _IApiNewsAppService.Search(keyword);
            var search = new Search();

            search.Keyword = keyword;
            search.News = news; //newsDto
            
            return search;
        }
        public async Task SaveSearch(NewsListDto newsList, Search search)
        {
            // Para cada resultado de search.News, agregar a newsList.News.Add(new)
            // Para esto, tengo que poder guardar las News como entidad New en la Db y asociarle a NewsList cada una de estas.
            var newsResponse = search.News;

            foreach (NewDto newE in newsResponse)
            {
                //agrega la entidad NewE a la base de datos
                var newMapped = ObjectMapper.Map<NewDto,New>(newE);
                await _INewAppService.InsertNewAync(newE);

                //asocia la newsList con la newE
                var newsListMapped = ObjectMapper.Map<NewsListDto, NewsListE>(newsList);
                newsListMapped.News.Add(newMapped);

                //actualiza la newsList en la base de datos
                newsList = ObjectMapper.Map<NewsListE,NewsListDto >(newsListMapped);
                await _INewsListAppService.UpdateNewsListAync(newsList);
            }

        }
    }
}
