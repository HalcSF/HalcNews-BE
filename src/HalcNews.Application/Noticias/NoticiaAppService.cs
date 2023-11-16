using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HalcNews.News
{
    public class NewAppService : HalcNewsAppService, INewAppService
    {
        private readonly IRepository<New, int> _repository;
        public NewAppService(IRepository<New, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<NewDto>> GetNewsAsync()
        {
            var news = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<New>, ICollection<NewDto>>(news);
        }

        public async Task<NewDto> GetNewAsync(int id)
        {
            var newE = await _repository.GetAsync(id); // newE porque new es una palabra reservada

            return ObjectMapper.Map<New, NewDto>(newE);
        }

        public async Task InsertNewAync(NewDto newE)
        {
            var newMapped = ObjectMapper.Map<NewDto, New>(newE);

            await _repository.InsertAsync(newMapped);
        }

        public async Task UpdateNewAync(NewDto newE)
        {
            var newMapped = ObjectMapper.Map<NewDto, New>(newE);

            await _repository.UpdateAsync(newMapped);
        }

        public async Task RemoveNewAync(NewDto newE)
        {
            var newMapped = ObjectMapper.Map<NewDto, New>(newE);
            await _repository.DeleteAsync(newMapped);
        }

    }
}
