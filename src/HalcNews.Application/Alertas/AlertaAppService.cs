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
            var alert = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<Alert>, ICollection<AlertDto>>(alert);
        }

        public async Task<AlertDto> GetAlertAsync(int id)
        {
            var alert = await _repository.GetAsync(id, includeDetails: true);

            return ObjectMapper.Map<Alert, AlertDto>(alert);
        }

        public async Task InsertAlertAsync(AlertDto alert)
        {
            var alertMapped = ObjectMapper.Map<AlertDto, Alert>(alert);

            await _repository.InsertAsync(alertMapped);
        }

        public async Task UpdateAlertAsync(AlertDto alert)
        {
            var alertMapped = ObjectMapper.Map<AlertDto, Alert>(alert);

            await _repository.UpdateAsync(alertMapped);
        }

        public async Task RemoveAlertAsync(AlertDto alert)
        {
            var alertMapped = ObjectMapper.Map<AlertDto, Alert>(alert);
            await _repository.DeleteAsync(alertMapped);
        }

        public async Task AddNotification(AlertDto alert, NotificationDto notification)
        {
            var alertMapped = ObjectMapper.Map<AlertDto, Alert>(alert);
            alert.Notifications.Add(notification);
            await _repository.UpdateAsync(alertMapped);
        }
    }
}

