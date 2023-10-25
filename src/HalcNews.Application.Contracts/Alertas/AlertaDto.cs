using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Alertas
{
    public class AlertDto : EntityDto<int>
    {
        public string Busqueda {  get; set; }
        public DateTime FechaEncontrada { get; set; }
        public bool Leida {  get; set; }

    }
}
