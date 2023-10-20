using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.NewsList
{
    public interface INewsListAppService : ICrudAppService<NewsListDto, int>
    {
    }
}
