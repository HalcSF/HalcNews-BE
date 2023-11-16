using HalcNews.ApiNews;
using HalcNews.ListaNoticias;
using HalcNews.NewsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.Busqueda
{
    public class SearchAppService : HalcNewsAppService, ISearchAppService
    {
        private readonly IApiNewsAppService _IApiNewsAppService;
        private readonly ISearchAppService _ISearchAppService;
        private readonly INewsListAppService _INewsListAppService;
        public SearchAppService(IApiNewsAppService apiNewsAppService, ISearchAppService searchAppService, INewsListAppService newsListAppService )
        {
            _IApiNewsAppService = apiNewsAppService;
            _ISearchAppService = searchAppService;
            _INewsListAppService = newsListAppService;
        }

        public async Task<Search> SearchNews(string keyword)
        {
            var news = await _IApiNewsAppService.Search(keyword);
            var search = new Search();

            search.Keyword = keyword;
            search.News = (ICollection<News.NewDto>)news;
            
            return search;
        }
       // public async Task SaveSearchs(NewsListDto newsList, Search search)
        //{
            
                // Para cada resultado de search.News, agregar a newsList.News.Add(new)
                // Para esto, tengo que poder guardar las News como entidad New en la Db y asociarle a NewsList cada una de estas.
        //}
    }
}
