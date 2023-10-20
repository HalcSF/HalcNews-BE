using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Source
{
  public interface IFuenteAppService: ICrudAppService<FuenteDto,int>
    {
    }
}
