using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Carpetas
{
    public class FolderAppService : CrudAppService<Folder, FolderDto, int>, IFolderAppService
    {
        public FolderAppService(IRepository<Folder, int> repository)
            : base(repository)
        {
        }
    }
}