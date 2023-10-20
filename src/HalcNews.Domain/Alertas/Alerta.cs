using HalcNews.Lecturas;
using HalcNews.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Alertas
{
    public class Alert : Entity<int> {
   
        public string Search {get; set;}
        public DateTime DateFound { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public bool isRead { get; set; }
    }
}