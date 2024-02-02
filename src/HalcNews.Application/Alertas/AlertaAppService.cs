using HalcNews.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Alertas
{
    public class AlertAppService : HalcNewsAppService, IAlertAppService
    {
        private readonly IRepository<Alert, int> _repository;
        public AlertAppService(IRepository<Alert, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<AlertDto>> GetAlertAsync()
        {
            var newsList = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<Alert>, ICollection<AlertDto>>(newsList);
        }

        public async Task<AlertDto> GetAlertAsync(int id)
        {
            var NewsList = await _repository.GetAsync(id);

            return ObjectMapper.Map<Alert, AlertDto>(NewsList);
        }

        public async Task InsertAlertAsync(AlertDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<AlertDto, Alert>(newsList);

            await _repository.InsertAsync(newsListMapped);
        }

        public async Task UpdateAlertAsync(AlertDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<AlertDto, Alert>(newsList);

            await _repository.UpdateAsync(newsListMapped);
        }

        public async Task RemoveAlertAsync(AlertDto newsList)
        {
            var newsListMapped = ObjectMapper.Map<AlertDto, Alert>(newsList);
            await _repository.DeleteAsync(newsListMapped);
        }
    }
}

