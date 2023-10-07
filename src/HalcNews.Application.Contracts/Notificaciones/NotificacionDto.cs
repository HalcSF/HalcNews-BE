using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Notificacion
{
    public class NotificacionDto : EntityDto<int>
    {
        public DateOnly Fecha { get; set; }
        public string Texto { get; set; }
        public string Link { get; set; }

    }
}
