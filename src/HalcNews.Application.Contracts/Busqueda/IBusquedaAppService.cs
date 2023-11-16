using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HalcNews.NewsList;

namespace HalcNews.Busqueda
{
    public interface ISearchAppService
    {
        Task<Search> SearchNews(string keyword);
        //Task SaveSearchs(NewsListDto newsList, Search search);
    }
}
