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
    public class SourceAppService : CrudAppService<Source, SourceDto, int>, ISourceAppService
    {
        public SourceAppService(IRepository<Source, int> repository)
            : base(repository)
        {
        }
    }
}

