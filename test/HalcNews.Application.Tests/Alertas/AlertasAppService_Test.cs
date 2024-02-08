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

namespace HalcNews.Alertas
{
    public class AlertasAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly IAlertAppService alertAppService;
        private readonly IFolderAppService folderAppService;

        public AlertasAppService_Test()
        {
            alertAppService = GetRequiredService<IAlertAppService>();
            folderAppService = GetRequiredService<IFolderAppService>();
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

            // Creamos la notificación
            var notificacion = new NotificationDto
            {
                DateFound = DateTime.Now,
                isRead = false,
                New = newE,
            };

            var notificacion2 = new NotificationDto
            {
                DateFound = DateTime.Now,
                isRead = false,
                New = newE,
            };

            await alertAppService.AddNotification(alert, notificacion);
            await alertAppService.AddNotification(alert, notificacion2);

            alert.Notifications.Count.ShouldBe(3);

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
                notifications.First().New.Author.ShouldBe("Autor");
            }
        }
    }
}
