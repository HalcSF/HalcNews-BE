using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Alertas
{
    public abstract class Alerta: Entity
    {
        private string _Busqueda;
        private DateOnly _FechaEncontrada;
        private bool _Leida;

        ///<sumary>
        /// Crea una nueva Alerta
        ///</sumary>
        /// <param name="busqueda">Búsqueda relacionada a la alerta</param>
        /// <param name="fechaEncontrada">Fecha que se encontró la búsqueda relacionada</param>
        /// <param name="leida">Si la alerta fue o no leída por el usuario</param>
        /// <returns>Alerta</returns>       

        public Alerta(string busqueda, DateOnly fechaEncontrada, bool leida)
        {
            _Busqueda = busqueda;
            _FechaEncontrada = fechaEncontrada;
            _Leida = leida;
        }

        public string Busqueda { get => _Busqueda; set => _Busqueda = value; }
        public DateOnly FechaEncontrada { get => _FechaEncontrada; set => _FechaEncontrada = value; }
        public bool Leida { get => _Leida; set => _Leida = value; }
    }
}