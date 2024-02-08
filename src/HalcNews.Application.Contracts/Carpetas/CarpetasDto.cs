using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using HalcNews.News;
using HalcNews.NewsList;
using HalcNews.Alertas;

namespace HalcNews.Carpetas
{
    public class FolderDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<NewDto>? News { get; set; }
        public ICollection<NewsListDto>? NewsLists { get; set; }
        public ICollection<AlertDto> Alerts { get; set; } = new List<AlertDto>();
    }
}
