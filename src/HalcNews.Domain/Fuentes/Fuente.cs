using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Fuentes
{
    public class Fuente : Entity<int>
    {
        public string Nombre { get; set; }
        public ICollection<Noticia> Noticias { get; set; }
    }
}
