﻿using HalcNews.INoticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.ListaNoticias
{
    public class EListaNoticias : Entity<int>, INoticia
    {
    
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
