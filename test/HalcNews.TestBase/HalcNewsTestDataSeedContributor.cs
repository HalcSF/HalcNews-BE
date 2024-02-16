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
using HalcNews.Notificaciones;

namespace HalcNews;

public class HalcNewsTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    //private readonly HandlerApiNews _handlerApiNews;

    private readonly IRepository<NewsListE, int> _newsListRepository;
    private readonly IRepository<Folder, int> _folderRepository;
    private readonly IRepository<Alert, int> _alertRepository;
    private readonly IRepository<Notification, int> _notificationRepository;
    public HalcNewsTestDataSeedContributor(IRepository<NewsListE, int> newsListRepository, IRepository<Folder, int> folderRepository, IRepository<Alert, int> alertRepository, IRepository<Notification, int> notificationRepository)
    {
        _newsListRepository = newsListRepository;
        _folderRepository = folderRepository;
        _alertRepository = alertRepository;
        _notificationRepository = notificationRepository;
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

        var notificacion = new Notification
        {
            DateFound = DateTime.Now,
            isRead = false,
            New = new New
            {
                Author = "Autor",
                Title = "Título",
                Description = "Descripción",
                Content = "Contenido",
                Date = DateTime.Now,
                Url = "URL",
                UrlImage = "URLImage"
            }
        };

        await _notificationRepository.InsertAsync(notificacion);


        await _folderRepository.InsertAsync(new Folder
        {
            Name = "CarpetaAlerta",
            Description = "Es la Carpeta de Alerta",
            Alerts = new List<Alert>
        {
            new Alert
            {
                Search = "BusquedaPrueba",
                CreationDate = DateTime.Now,
                isActive = true,
                FolderId = 1,
                //Notifications = new List<Notification>{notificacion},
                Notifications = new List<Notification>{notificacion},
            }
        }
        });

        

        


    }
}
