using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HalcNews.Noticias
{
    public interface INoticiaAppService : ICrudAppService<NoticiaDto, int>
    {

    }
}
