﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HalcNews.NewsList;
using HalcNews.Carpetas;

namespace HalcNews.Busqueda
{
    public interface ISearchAppService
    {
        Task<Search> SearchNews(string keyword);
        Task SaveSearch(NewsListDto newsList, Search search);
        Task AddAlert(FolderDto folder, string keyword);
    }
}
