using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace HalcNews.Carpetas
{
    public interface IFolderAppService : ICrudAppService<FolderDto, int>
    {
    }
}
