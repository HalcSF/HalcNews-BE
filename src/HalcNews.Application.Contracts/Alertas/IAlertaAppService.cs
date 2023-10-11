using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Alertas
{
    public interface IAlertaAppService : ICrudAppService<AlertaDto, int>
    {
    }
}
