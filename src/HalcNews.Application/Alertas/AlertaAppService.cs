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
    public class AlertaAppService : CrudAppService<Alert, AlertDto, int>, IAlertaAppService
    {
        public AlertaAppService(IRepository<Alert, int> repository)
            : base(repository)
        {
        }
    }
}
