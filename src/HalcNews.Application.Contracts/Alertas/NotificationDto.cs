using HalcNews.News;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Alertas
{
    public class NotificationDto : EntityDto<int>
    {

        public DateTime DateFound { get; set; } = DateTime.Now;
        public bool isRead { get; set; } = false;

        //// Relación con Alert
        //public Alert Alert { get; set; }

        // Relación con Noticia

        public NewDto? New { get; set; } = new NewDto();

    }
}
