using HalcNews.Fuentes;
using HalcNews.Lecturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Noticias
{
    public class Noticia : Entity<int>
    {
        public string Autor {  get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public string Url { get; set; }
        public string UrlImagen { get; set; }

        // asociaciones
        public ICollection<Lectura> Lecturas { get; set; }
        public Fuente Fuente { get; set; }

    }
}

