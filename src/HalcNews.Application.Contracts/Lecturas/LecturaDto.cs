using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Lectura
{
    public class LecturaDto: EntityDto<int>
    {
        public DateTiem FechaLectura { get; set;}
    }
}
