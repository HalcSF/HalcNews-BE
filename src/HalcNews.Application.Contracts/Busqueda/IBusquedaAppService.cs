using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HalcNews.NewsList;
using HalcNews.News;

namespace HalcNews.Busqueda
{
    public interface ISearchAppService
    {
        Task<Search> SearchNews(string keyword);
        Task SaveSearch(NewsListDto newsList, Search search);
        Task AddAlert(int folderId, string keyword);
        Task AddNewInFolder(int folderId, NewDto newE);
        Task AddNewListInFolder(int folderId, NewsListDto newList);
    }
}
