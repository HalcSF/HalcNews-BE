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
            //Arrage
            var alert = await alertAppService.GetAlertAsync(1);

            // Supongamos que se encontró la siguiente noticia nueva a la que se quiere notificar
            var newE = new NewDto
            {
                Author = "Tobias Grandi",
                Title = "TituloEjemplo",
                Description = "DescripcionEjemplo",
                Content = "ContentEjemplo",
                Date = DateTime.Now,
                Url = "URL",
                UrlImage = "URLimage"
            };

            //var notificacion = new NotificationDto
            //{
            //    DateFound = DateTime.Now,
            //    isRead = false,
            //    New = newE,
            //};

            var date = DateTime.Now;
            var notificacion = await notificationAppService.CreateNotification(newE, date, alert);
            await alertAppService.AddNotification(alert, notificacion);
            var notificaciones = await notificationAppService.GetNotificationAsync();

            alert.Notifications.Count.ShouldBe(2);
            notificaciones.Count.ShouldBe(2);
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
