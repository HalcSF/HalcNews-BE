using HalcNews.Fuentes;
using HalcNews.Lecturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace HalcNews.Noticias
{
    public class New : Entity<int>
    {
        public string Author {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string UrlImage { get; set; }

        // asociaciones
        public ICollection<Lectury> Lecturies { get; set; }
        public Source Source { get; set; }
        public int SourceId { get; set; }

    }
}

