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
    public class AlertAppService : CrudAppService<Alert, AlertDto, int>, IAlertAppService
    {
        public AlertAppService(IRepository<Alert, int> repository)
            : base(repository)
        {
        }
    }
}
