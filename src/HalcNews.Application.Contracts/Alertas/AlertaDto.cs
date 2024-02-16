using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using HalcNews.Carpetas;
using HalcNews.Notificaciones;

namespace HalcNews.Alertas
{
    public class AlertDto : EntityDto<int>
    {
        public string Search { get; set; }
        public DateTime CreationDate { get; set; }
        public bool isActive { get; set; }

        public int FolderId { get; set; }

        public ICollection<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();

    }
}
