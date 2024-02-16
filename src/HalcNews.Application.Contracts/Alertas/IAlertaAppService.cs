using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using HalcNews.Notificaciones;

namespace HalcNews.Alertas
{
    public interface IAlertAppService : IApplicationService
    {
        Task<ICollection<AlertDto>> GetAlertAsync();
        Task<AlertDto> GetAlertAsync(int id);
        Task InsertAlertAsync(AlertDto newAlert);
        Task UpdateAlertAsync(AlertDto newAlert);
        Task RemoveAlertAsync(AlertDto newAlert);
        Task AddNotification(AlertDto alert, NotificationDto notification);
    }
}