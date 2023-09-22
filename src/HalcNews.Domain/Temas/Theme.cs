using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Temas
{
    public class Theme : Entity<int>
    {
        public string Name { get; set; }
    }
}
