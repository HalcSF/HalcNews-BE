using HalcNews.INoticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.ListaNoticias
{
    public class NewsListE : Entity<int>
    {
    
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
