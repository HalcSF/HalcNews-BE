using HalcNews.Alertas;
using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Notificaciones
{
    public class Notification : Entity<int>
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Alert Alert { get; set; }

        public int AlertID { get; set; } 
    }
}