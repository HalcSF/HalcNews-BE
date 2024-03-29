﻿using HalcNews.Notificaciones;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.News
{
    public class NewDto: EntityDto<int>
    {
        public string? Author { get; set; } = "";
        public string? Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? Content { get; set; } = "";
        public DateTime? Date { get; set; } = DateTime.Now;
        public string? Url { get; set; } = "";
        public string? UrlImage { get; set; } = "";

        public ICollection<NotificationDto>? Notifications { get; set; }

    }
}
