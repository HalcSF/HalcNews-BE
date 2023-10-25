using HalcNews.Fuentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Fuentes
{
    public class FuenteAppService : CrudAppService<Source, SourceDto, int>, IFuenteAppService
    {
        public FuenteAppService(IRepository<Source, int> repository)
            : base(repository)
        {
        }
    }
}

