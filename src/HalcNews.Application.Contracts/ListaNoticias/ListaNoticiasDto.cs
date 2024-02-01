using HalcNews.News;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HalcNews.NewsList
{
    public class NewsListDto : EntityDto<int>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<NewDto> News { get; set; }
    }
}
