using HalcNews.Alertas;
using HalcNews.News;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Notificaciones
{
    public class NotificationDto : EntityDto<int>
    {

        public DateTime DateFound { get; set; } = DateTime.Now;
        public bool isRead { get; set; } = false;

        // Relación con Alert
        public AlertDto? Alert { get; set; }

        // Relación con Noticia

        public NewDto? New { get; set; }

    }
}
