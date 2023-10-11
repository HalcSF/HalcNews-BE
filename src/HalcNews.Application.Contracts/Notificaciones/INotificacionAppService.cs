using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Notificacion
{
    public interface INotificacionAppService : ICrudAppService<NotificacionDto, int>
    {
    }
}
