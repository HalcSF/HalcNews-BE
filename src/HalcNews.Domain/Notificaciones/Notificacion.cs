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
    public class Notificacion : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public string Link { get; set; }
        public Alerta Alerta { get; set; }

        public int AlertaId { get; set; } 
    }
}