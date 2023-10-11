using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using HalcNews.ListaNoticias;

namespace HalcNews.ListaNoticias
{
    public class ListaNoticiasAppService : CrudAppService<EListaNoticias,ListaNoticiasDto,int>, IListaNoticiasAppService
    {
        public ListaNoticiasAppService(IRepository<EListaNoticias, int> repository)
            : base(repository)
        {
        }
    }
}
