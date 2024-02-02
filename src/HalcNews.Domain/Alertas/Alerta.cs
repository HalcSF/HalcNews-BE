using Abp.Authorization.Users;
using HalcNews.Carpetas;
using HalcNews.Lecturas;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Alertas
{
    public class Alert : Entity<int>
    {

        public string Search { get; set; }
        public DateTime DateFound { get; set; }
        public bool isRead { get; set; }

        // 1 .. * Usuario ?
        // public IdentityUser Usuario { get; set; }

        // 1 .. 0.1 Folder
        public Folder? Folder { get; set; }

    }
}