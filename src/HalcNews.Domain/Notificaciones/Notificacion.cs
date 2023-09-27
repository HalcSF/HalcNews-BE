using HalcNews.INoticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.Notificaciones
{
    public abstract class Notificacion
    {
        private DateOnly _Fecha;
        private string _Texto;
        private string _Link;

        ///<sumary>
        /// Crea una nueva Notificación
        ///</sumary>
        /// <param name="fecha">Fecha de creación de la notificación</param>
        /// <param name="texto">Contenido de la notificación</param>
        /// <param name="link">Link correspondiente a la búsqueda de la alerta</param>
        /// <returns>Notficación</returns>

        public Notificacion(DateOnly fecha, string texto, string link)
        {
        _Fecha = fecha;
        _Texto = texto;
        _Link = link;
        }

        public DateOnly Fecha { get => _Fecha; set => _Fecha = value; }
        public string Texto { get => _Texto; set => _Texto = value; }
        public string Link { get => _Link; set => _Link = value; }
    }
}