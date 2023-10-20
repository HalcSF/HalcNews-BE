using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.News
{
    public class NewAppService : CrudAppService<New,NewDto,int> , INewAppService
    {
        public NewAppService(IRepository<New,int> repository) 
            : base(repository)
        {
            
        }
    }
}
