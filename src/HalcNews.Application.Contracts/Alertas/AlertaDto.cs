﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.Alertas
{
    public class AlertDto : EntityDto<int>
    {
        public string Search {  get; set; }
        public DateTime DateFound { get; set; }
        public bool isRead {  get; set; }

    }
}
