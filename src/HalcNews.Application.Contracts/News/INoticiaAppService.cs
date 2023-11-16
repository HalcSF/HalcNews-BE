using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HalcNews.News
{
    public interface INewAppService : IApplicationService
    {
        Task<ICollection<NewDto>> GetNewsAsync();
        Task<NewDto> GetNewAsync(int id);
        Task InsertNewAync(NewDto newE);
        Task UpdateNewAync(NewDto newE);
        Task RemoveNewAync(NewDto newE);



    }
}
