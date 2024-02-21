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
using HalcNews.Busqueda;
using AutoMapper.Internal.Mappers;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace HalcNews;

public class HalcNewsTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{

    private readonly IRepository<NewsListE, int> _newsListRepository;
    private readonly IRepository<Folder, int> _folderRepository;
    private readonly IRepository<Alert, int> _alertRepository;
    private readonly IRepository<Notification, int> _notificationRepository;
    private readonly IRepository<New, int> _newRepository;

    public HalcNewsTestDataSeedContributor(IRepository<NewsListE, int> newsListRepository, 
        IRepository<Folder, int> folderRepository, 
        IRepository<Alert, int> alertRepository, 
        IRepository<Notification, int> notificationRepository, 
        IRepository<New, int> newRepository)
    {
        _newsListRepository = newsListRepository;
        _folderRepository = folderRepository;
        _alertRepository = alertRepository;
        _notificationRepository = notificationRepository;
        _newRepository = newRepository;

    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _newsListRepository.InsertAsync(new NewsListE
        {
            Date = DateTime.Now,
            Title = "Título",
            Description = "Descripción",
            News = new List<New>()
        });

        var newE = new New
        {
            Author = "Autor",
            Title = "Título",
            Description = "Descripción",
            Content = "Contenido",
            Date = DateTime.Now,
            Url = "URL",
            UrlImage = "URLImage"
        };

        await _newRepository.InsertAsync(newE);

        var newAlert = new Alert
        {
            Search = "Apple",
            CreationDate = DateTime.Now,
            isActive = true,
            FolderId = 1,
            Notifications = new List<Notification>{new Notification
            {
                DateFound = DateTime.Now,
                isRead = false,
                New = newE,
            }},
        };

        await _alertRepository.InsertAsync(newAlert);

        var folder = new Folder
        {
            Name = "CarpetaAlerta",
            Description = "Es la Carpeta de Alerta",
            Alerts = new List<Alert>()
        };

        folder.Alerts.Add(newAlert);

        await _folderRepository.InsertAsync(folder);

    }
 };