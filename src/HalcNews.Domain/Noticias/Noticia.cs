using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalcNews.INoticias;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Noticias
{
    public abstract class Noticia : Entity<int>,INoticia
    {
        public string Autor {  get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateOnly Fecha { get; set; }
        public string Url { get; set; }
        public string UrlImagen { get; set; }
    }
}
