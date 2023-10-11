using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Alertas
{
    public class AlertaDto : EntityDto<int>
    {
        public string Busqueda {  get; set; }
        public DateOnly FechaEncontrada { get; set; }
        public bool Leida {  get; set; }

    }
}
