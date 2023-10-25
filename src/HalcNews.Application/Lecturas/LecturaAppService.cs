using HalcNews.Lecturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Lecturas
{
    public class LecturaAppService : CrudAppService<Lectury, LecturyDto, int>, ILecturaAppService
    {
        public LecturaAppService(IRepository<Lectury, int> repository)
            : base(repository)
        {
        }
    }
}
