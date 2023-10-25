using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Lecturas
{
    public interface ILecturaAppService : ICrudAppService<LecturyDto, int>
    {
    }
}
