using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Lecturas
{
    public class LecturyDto: EntityDto<int>
    {
        public DateTime DateLectury { get; set;}
    }
}
