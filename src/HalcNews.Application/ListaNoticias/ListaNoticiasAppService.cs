using HalcNews.ListaNoticias;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.NewsList
{
    public class NewsListAppService : HalcNewsAppService, INewsListAppService
    {
        private readonly IRepository<NewsListE, int> _repository;
        public NewsListAppService(IRepository<NewsListE, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<NewsListDto>> GetNewsListAsync()
        {
            var newsList = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<NewsListE>, ICollection<NewsListDto>>(newsList);
        }

        public async Task<NewsListDto> GetNewsListAsync(int id)
        {
            var NewsList = await _repository.GetAsync(id, includeDetails:true);

            return ObjectMapper.Map<NewsListE, NewsListDto>(NewsList);
        }

        public async Task InsertNewsListAync(NewsListDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<NewsListDto,NewsListE>(newsList);

            await _repository.InsertAsync(newsListMapped);
        }

        public async Task UpdateNewsListAync(NewsListDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<NewsListDto, NewsListE>(newsList);

            await _repository.UpdateAsync(newsListMapped);
        }

        public async Task RemoveNewsListAync(NewsListDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<NewsListDto, NewsListE>(newsList);
            await _repository.DeleteAsync(newsListMapped);
        }


    }
}
