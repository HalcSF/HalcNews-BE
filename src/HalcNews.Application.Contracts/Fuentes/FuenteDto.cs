using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Fuentes
{
    public class FuenteDto : EntityDto<int>
    {
        public string Nombre { get; set; }

    }
}
