﻿using HalcNews.Fuentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Fuentes
{
    public class FuenteAppService : CrudAppService<Fuente, FuenteDto, int>, IFuenteAppService
    {
        public FuenteAppService(IRepository<Fuente, int> repository)
            : base(repository)
        {
        }
    }
}
