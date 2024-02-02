using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HalcNews.Alertas
{
    public class NotificacionAppService : HalcNewsAppService, INotificationAppService
    {
        private readonly IRepository<Notification, int> _repository;
        public NotificacionAppService(IRepository<Notification, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<NotificationDto>> GetNotificationAsync()
        {
            var notification = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<Notification>, ICollection<NotificationDto>>(notification);
        }

        public async Task<NotificationDto> GetNotificationAsync(int id)
        {
            var notification = await _repository.GetAsync(id);

            return ObjectMapper.Map<Notification, NotificationDto>(notification);
        }

        public async Task InserNotificationAsync(NotificationDto Notification)
        {
            var notificationMapped = ObjectMapper.Map<NotificationDto, Notification>(Notification);

            await _repository.InsertAsync(notificationMapped);
        }

        public async Task UpdateNotificationAsync(NotificationDto Notification)
        {
            var notificationMapped = ObjectMapper.Map<NotificationDto, Notification>(Notification);

            await _repository.UpdateAsync(notificationMapped);
        }

        public async Task RemoveNotificationAsync(NotificationDto Notification)
        {
            var notificationMapped = ObjectMapper.Map<NotificationDto, Notification>(Notification);
            await _repository.DeleteAsync(notificationMapped);
        }
    }
}
