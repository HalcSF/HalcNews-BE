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

        public string Search { get; set; } = "";
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;

        // 1 .. 0.1 Folder
        public int FolderId { get; set; }
            
        // 1 .. * Notifications
        public ICollection<Notification>? Notifications { get; set; }

    }
}