using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Themes
{
    public class ThemeDto : EntityDto<int>
    {
        public string Name { get; set; }

    }
}
