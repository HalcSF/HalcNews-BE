using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Lecturas
{
    public class Lectura : Entity<int>
    {
        public DateOnly FechaLectura {  get; set; }
    }
}
