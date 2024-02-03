using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Estadisticas
{
    public class StatsDto: EntityDto<int>
    {
        public DateTime Date { get; set; }
        // string Author { get; set; }
        public double ResponseTime { get; set; } //Tiempo de respuesta de la API en milisegundos
        public int TotalArticles { get; set; }
        public int ArticlesWithImages { get; set; }
        public string Search { get; set; } //Puede ser null en caso de que se realice una llamada a la API sin parámetro de búsqueda
    }
}
