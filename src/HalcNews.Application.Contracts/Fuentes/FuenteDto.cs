using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Fuentes
{
    public class SourceDto : EntityDto<int>
    {
        public string Name { get; set; }

    }
}
