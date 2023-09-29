using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.ListaNoticias
{
    public interface IListaNoticiasAppService : ICrudAppService<ListaNoticiasDto, int>
    {
    }
}
