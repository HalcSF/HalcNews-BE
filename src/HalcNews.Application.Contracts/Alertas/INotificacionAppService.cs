using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HalcNews.Alertas
{
    public interface INotificationAppService : IApplicationService
    {
        Task<ICollection<NotificationDto>> GetNotificationAsync();
        Task<NotificationDto> GetNotificationAsync(int id);
        Task InsertNotificationAsync(NotificationDto Notificacion);
        Task UpdateNotificationAsync(NotificationDto Notificacion);
        Task RemoveNotificationAsync(NotificationDto Notificacion);
    }
}
