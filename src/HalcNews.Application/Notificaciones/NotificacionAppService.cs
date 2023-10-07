using HalcNews.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Notificaciones
{
    public class NotificacionesAppService : CrudAppService<Notificacion, NotificacionDto, int>, INotificacionAppService
    {
        public NotificacionAppService(IRepository<Notificacion, int> repository)
            : base(repository)
        {
        }
    }
}
