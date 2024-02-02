using Abp.Domain.Entities;
using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.Alertas
{
    public class Notification : Entity<int>
    {

        public DateTime DateFound { get; set; } = DateTime.Now;
        public bool isRead { get; set; } = false;

        // Relación con Alert
        public Alert Alert { get; set; }

        // Relación con Noticia

        public New New { get; set; }

    }
}
