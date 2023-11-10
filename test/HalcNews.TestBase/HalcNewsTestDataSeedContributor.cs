using HalcNews.ApiNews;
using HalcNews.ListaNoticias;
using HalcNews.Temas;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace HalcNews;

public class HalcNewsTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    //private readonly HandlerApiNews _handlerApiNews;

    private readonly IRepository<NewsListE, int> _newsListRepository;
    public HalcNewsTestDataSeedContributor(IRepository<NewsListE, int> newsListRepository)
    {
        _newsListRepository = newsListRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _newsListRepository.InsertAsync(new NewsListE
        {
            Date = DateTime.Now,
            Title = "Título",
            Description ="Descripción"

        });
    }
}
