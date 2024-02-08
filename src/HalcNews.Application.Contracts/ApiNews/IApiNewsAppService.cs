using HalcNews.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.ApiNews
{
    public interface IApiNewsAppService 
    {
        Task<ICollection<NewDto>> Search(string? Search);
        Task<ICollection<NewDto>> SearchFromDate(string? Search, DateTime date);
    }
}
