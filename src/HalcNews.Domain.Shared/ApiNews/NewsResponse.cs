using System;
using System.Collections.Generic;
using System.Text;

namespace HalcNews.ApiNews
{
    public class NewsResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }

    }

    public class ArticleDto
    {
        // public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }

    }

    public class SourceResponse
    {
        public string Status { get; set; }
        public ICollection<Source> Sources { get; set; }
    }

    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Lenguage { get; set; }
        public string Country { get; set; }
    }
}
