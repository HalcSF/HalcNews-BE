using HalcNews.News;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace HalcNews.ApiNews
{
    public class ApiNewsAppService : HalcNewsAppService, IApiNewsAppService
    {
        private readonly IApiNews _apiNews;
        public ApiNewsAppService(IApiNews apiNewsAppService) 
        {
            _apiNews = apiNewsAppService;
        }
        public async Task<ICollection<NewDto>> Search(string? Search)
        {
            var news = await _apiNews.GetNewsAsync(Search);

            return ManualMapper.MapArticlesToNews(news);
        }


    }
}
