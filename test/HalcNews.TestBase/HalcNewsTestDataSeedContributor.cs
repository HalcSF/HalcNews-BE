using HalcNews.Alertas;
using HalcNews.ApiNews;
using HalcNews.Carpetas;
using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using HalcNews.Temas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace HalcNews;

public class HalcNewsTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    //private readonly HandlerApiNews _handlerApiNews;

    private readonly IRepository<NewsListE, int> _newsListRepository;
    private readonly IRepository<Folder, int> _folderRepository;
    public HalcNewsTestDataSeedContributor(IRepository<NewsListE, int> newsListRepository, IRepository<Folder, int> folderRepository)
    {
        _newsListRepository = newsListRepository;
        _folderRepository = folderRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _newsListRepository.InsertAsync(new NewsListE
        {
            Date = DateTime.Now,
            Title = "Título",
            Description ="Descripción",
            News = new List<New>(),
        });

        await _folderRepository.InsertAsync(new Folder
        {
            Name = "CarpetaAlerta",
            Description = "Es la Carpeta de Alerta",
            //News = new List<New>(),
            //NewsLists = new List<NewsListE>(),
            //Alerts = new List<Alert>(),
        });

    }
}
