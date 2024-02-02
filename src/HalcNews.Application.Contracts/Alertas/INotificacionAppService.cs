using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HalcNews.Alertas
{
    public interface INotificationAppService : IApplicationService
    {
        Task<ICollection<AlertDto>> GetNotificacionAsync();
        Task<AlertDto> GetNotificacionAsync(int id);
        Task InsertNotificacionAsync(NotificationDto Notificacion);
        Task UpdateNotificacionAsync(NotificationDto Notificacion);
        Task RemoveNotificacionAsync(NotificationDto Notificacion);
    }
}
