﻿using HalcNews.Lecturas;
using HalcNews.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Alertas
{
    public class Alerta : Entity<int> {
   
        public string Busqueda {get; set;}
        public DateTime FechaEncontrada { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }
        public bool Leida { get; set; }
    }
}