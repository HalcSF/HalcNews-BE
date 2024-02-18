using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalcNews.Alertas;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Abp.Notifications;
using HalcNews.News;
using HalcNews.Carpetas;
using HalcNews.Notificaciones;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;



namespace HalcNews.Alertas
{
    public class AlertasAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly IAlertAppService alertAppService;
        private readonly IFolderAppService folderAppService;
        private readonly INotificationAppService notificationAppService;

        public AlertasAppService_Test()
        {
            alertAppService = GetRequiredService<IAlertAppService>();
            folderAppService = GetRequiredService<IFolderAppService>();
            notificationAppService = GetRequiredService<INotificationAppService>();
        }

        [Fact]
        public async Task Should_Add_Notification()
        {
            // Arrange
            var alert = await alertAppService.GetAlertAsync(1);

            // Supongamos que se encontró la siguiente noticia nueva a la que se quiere notificar
            var newE1 = new NewDto
            {
                Author = "Tobias Grandi",
                Title = "TituloEjemplo",
                Description = "DescripcionEjemplo",
                Content = "ContentEjemplo",
                Date = DateTime.Now,
                Url = "URL",
                UrlImage = "URLimage"
            };

            var notificacion1 = new NotificationDto
            {
                DateFound = DateTime.Now,
                isRead = false,
                New = newE1,
            };

            await alertAppService.AddNotification(alert, notificacion1);

            // Crear una nueva instancia de NewDto para la segunda notificación
            var newE2 = new NewDto
            {
                Author = "Tobias Grandi",
                Title = "TituloEjemplo2",
                Description = "DescripcionEjemplo2",
                Content = "ContentEjemplo2",
                Date = DateTime.Now,
                Url = "URL2",
                UrlImage = "URLimage2"
            };

            var notificacion2 = new NotificationDto
            {
                DateFound = DateTime.Now,
                isRead = false,
                New = newE2,
            };

            await alertAppService.AddNotification(alert, notificacion2);

            var notificaciones = await notificationAppService.GetNotificationAsync();

            // Nos traemos la alerta actualizada
            alert = await alertAppService.GetAlertAsync(1);

            alert.Notifications.Count.ShouldBe(3);
            notificaciones.Count.ShouldBe(3);
            notificaciones.First().isRead.ShouldBeFalse();
        }

        [Fact]
        public async Task Should_Get_All_Notifications()
        {
            // Arrange
            var alerts = await alertAppService.GetAlertAsync();

            var notifications = new List<NotificationDto>();


            foreach (var alert in alerts)
            {
                foreach (var notification in alert.Notifications)
                {
                    notifications.Add(notification);
                }

                notifications.Count.ShouldBe(1);
                //notifications.First().New.Author.ShouldBe("Autor");
            }
        }
    }
}
