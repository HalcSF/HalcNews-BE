using HalcNews.INoticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.ListaNoticias
{
    public abstract class ListaNoticias : Entity<int>, INoticias
    {
        private DateOnly _Fecha;
        private string _Descripcion;
        private string _Titulo;

        ///<sumary>
        /// Crea una nueva instancia de la clase
        ///</sumary>
        /// <param name="fecha"> autor de la noticia.</param>
        /// <param name="descripcion">descripcion de la noticia. </param>
        /// <param name="titulo">titulo de la noticia.</param>
        /// <returns>ListaNoticias</returns>

        public ListaNoticias(DateOnly fecha, string descripcion, string titulo)
        {
            _Fecha = fecha;
            _Titulo = titulo;
            _Descripcion = descripcion;
        }

        public DateOnly Fecha { get => _Fecha; set => _Fecha = value; }
        public string Titulo { get => _Titulo; set => _Titulo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
