﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Fuentes
{
    public interface ISourceAppService : ICrudAppService<SourceDto, int>
    {
    }
}
