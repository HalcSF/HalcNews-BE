using System;
using System.Collections.Generic;
using System.Text;
using HalcNews.News;

namespace HalcNews.Busqueda
{
    public class Search
    {
        public string Keyword { get; set; }
        public ICollection<NewDto> News { get; set; }

    }
}
