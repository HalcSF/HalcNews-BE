using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HalcNews.Carpetas
{
    public interface IFolderAppService : IApplicationService
    {
        Task<ICollection<FolderDto>> GetFolderAsync();
        Task<FolderDto> GetFolderAsync(int id);
        Task InsertFolderAsync(FolderDto newsList);
        Task UpdateFolderAsync(FolderDto newsList);
        Task RemoveFolderAsync(FolderDto newsList);
    }
}
