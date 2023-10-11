using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Lectura
{
    public interface ILecturaAppService : ICrudAppService<LecturaDto, int>
    {
    }
}
