using HalcNews.Noticias;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using Abp.Authorization.Users;

namespace HalcNews.Lecturas
{
    public class Lectura : Entity<int>
    {
        public DateOnly FechaLectura {  get; set; }

        // asociaciones
        // public AbpUser<> Usuario { get; set; } // esperar resp del profe
        public Noticia Noticia { get; set; }
        public int NoticiaId {  get; set; }
    }
}
