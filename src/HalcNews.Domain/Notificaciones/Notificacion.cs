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
    public abstract class Notificacion : Entity <int>
    {
        public DateOnly Fecha { get; set; }
        public string Texto { get; set; }
        public string Link { get; set; }
        public Alerta Alerta { get; set; }
    }
}