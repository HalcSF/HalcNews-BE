using HalcNews.Noticias;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using Abp.Authorization.Users;

namespace HalcNews.Lecturas
{
    public class Lectury : Entity<int>
    {
        public DateTime DateLectury {  get; set; }

        // asociaciones
        // public AbpUser<> Usuario { get; set; } // esperar resp del profe

        // 1 .. * New
        public New New { get; set; }
    }
}
