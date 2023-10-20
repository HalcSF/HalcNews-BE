using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HalcNews.News
{
    public interface INewAppService : ICrudAppService<NewDto, int>
    {

    }
}
