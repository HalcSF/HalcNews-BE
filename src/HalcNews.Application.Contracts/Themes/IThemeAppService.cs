using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HalcNews.Themes
{
    public interface IThemeAppService : ICrudAppService<ThemeDto,int>
    {

    }
}
