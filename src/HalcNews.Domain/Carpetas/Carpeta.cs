using HalcNews.Alertas;
using HalcNews.ListaNoticias;
using HalcNews.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Carpetas
{
    public class Folder : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // * .. * News
        public ICollection<New>? News { get; set; }
        // *..* NewsList
        public ICollection<NewsListE>? NewsLists { get; set; }
        // 0..1 .. * Alert
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    }
}
