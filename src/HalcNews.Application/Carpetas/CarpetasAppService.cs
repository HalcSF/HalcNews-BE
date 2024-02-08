using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HalcNews.Carpetas
{
    public class FolderAppService : HalcNewsAppService, IFolderAppService
    {
        private readonly IRepository<Folder, int> _repository;
        public FolderAppService(IRepository<Folder, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<FolderDto>> GetFolderAsync()
        {
            var folders = await _repository.GetListAsync(includeDetails: true);

            foreach (var folder in folders)
            {
                await _repository.EnsureCollectionLoadedAsync(folder, f => f.News);
                await _repository.EnsureCollectionLoadedAsync(folder, f => f.NewsLists);
                await _repository.EnsureCollectionLoadedAsync(folder, f => f.Alerts);

            }

            return ObjectMapper.Map<ICollection<Folder>, ICollection<FolderDto>>(folders);
        }

        public async Task<FolderDto> GetFolderAsync(int id)
        {
            var folder = await _repository.GetAsync(id, includeDetails: true);

            await _repository.EnsureCollectionLoadedAsync(folder, f => f.News);
            await _repository.EnsureCollectionLoadedAsync(folder, f => f.NewsLists);
            await _repository.EnsureCollectionLoadedAsync(folder, f => f.Alerts);

            return ObjectMapper.Map<Folder, FolderDto>(folder);
        }

        public async Task InsertFolderAsync(FolderDto folder)
        {
            var folderMapped = ObjectMapper.Map<FolderDto, Folder>(folder);

            await _repository.InsertAsync(folderMapped, autoSave: true);
        }

        public async Task UpdateFolderAsync(FolderDto folder)
        {
            var folderMapped = ObjectMapper.Map<FolderDto, Folder>(folder);

            await _repository.UpdateAsync(folderMapped);
        }

        public async Task RemoveFolderAsync(FolderDto folder)
        {
            var folderMapped = ObjectMapper.Map<FolderDto, Folder>(folder);
            await _repository.DeleteAsync(folderMapped);
        }

    }
}