using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;


namespace HalcNews.NewsList
{
    public interface INewsListAppService : IApplicationService
    {
        Task<ICollection<NewsListDto>> GetNewsListAsync();
        Task<NewsListDto> GetNewsListAsync(int id);
        Task InsertNewsListAync(NewsListDto newsList);
        Task UpdateNewsListAync(NewsListDto newsList);
    }
}
