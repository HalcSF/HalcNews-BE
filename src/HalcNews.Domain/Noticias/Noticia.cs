﻿using HalcNews.Fuentes;
using HalcNews.Lecturas;
using HalcNews.ListaNoticias;
using HalcNews.Carpetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using HalcNews.Notificaciones;

namespace HalcNews.Noticias
{
    public class New : Entity<int>
    {
        public string? Author { get; set; } = "";
        public string? Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? Content { get; set; } = "";
        public DateTime? Date { get; set; } = DateTime.Now;
        public string? Url { get; set; } = "";
        public string? UrlImage { get; set; } = "";

        // 1 .. * Lecturies
        public ICollection<Lectury>? Lecturies { get; set; }

        // * .. * NewsList
        public ICollection<NewsListE>? NewsLists { get; set; }

        // * .. *  Folder
        public ICollection<Folder>? Folders { get; set; }

        public ICollection<Notification>? Notifications { get; set; }

    }
}

