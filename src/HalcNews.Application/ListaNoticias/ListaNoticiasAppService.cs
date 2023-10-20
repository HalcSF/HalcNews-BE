using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using HalcNews.ListaNoticias;

namespace HalcNews.NewsList
{
    public class NewsListAppService : CrudAppService<NewsListE,NewsListDto,int>, INewsListAppService
    {
        public NewsListAppService(IRepository<NewsListE, int> repository)
            : base(repository)
        {
        }
    }
}
