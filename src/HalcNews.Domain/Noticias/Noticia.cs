using HalcNews.INoticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Notice
{
    public class Noticia : Entity<int>, INoticias
    {
        private string _Autor;
        private string _Titulo;
        private string _Descripcion;
        private string _Contenido;
        private DateOnly _Fecha;
        private string _Url;
        private string _UrlImagen;

        //CONSTRUCTOR
        /// <summary>
        /// Crea una nueva instancia de la clase
        /// </summary>
        /// <param name="autor"> autor de la noticia.</param>
        /// <param name="titulo"> titulo de la noticia.</param>
        /// <param name="descripcion">descripcion de la noticia.</param>
        /// <param name="contenido">contenido de la noticia.</param>
        /// <param name="fecha">fecha de la noticia</param>
        /// <param name="url">Url de la pagina.</param>
        /// <param name="urlImagen">Url de la imagen.</param>
        /// <returns>Noticia</returns>
        public Noticia(string autor, string titulo, string descripcion, string contenido, DateOnly fecha, string url, string urlImagen)
        {
            _Autor = autor;
            _Titulo = titulo;
            _Descripcion = descripcion;
            _Contenido = contenido;
            _Fecha = fecha;
            _Url = url;
            _UrlImagen = urlImagen;
        }
        public string Autor { get => _Autor; set => _Autor = value; }
        public string Titulo { get => _Titulo; set => _Titulo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Contenido { get => _Contenido; set => _Contenido = value; }
        public DateOnly Fecha { get => _Fecha; set => _Fecha = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string UrlImagen { get => _UrlImagen; set => _UrlImagen = value; }
    }
}

