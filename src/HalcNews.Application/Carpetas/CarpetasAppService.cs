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
            var folder = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<Folder>, ICollection<FolderDto>>(folder);
        }

        public async Task<FolderDto> GetFolderAsync(int id)
        {
            var folder = await _repository.GetAsync(id, includeDetails:true);
            return ObjectMapper.Map<Folder, FolderDto>(folder);
        }

        public async Task InsertFolderAsync(FolderDto folder)
        {
            var folderMapped = ObjectMapper.Map<FolderDto, Folder>(folder);

            await _repository.InsertAsync(folderMapped);
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