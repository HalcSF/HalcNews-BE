using HalcNews.News;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.ApiNews
{
    public class ManualMapper
    {
        public static ICollection<NewDto> MapArticlesToNews(ICollection<ArticleDto> articles)
        {
            var newsList = new List<NewDto>();

            foreach (var article in articles)
            {
                var newsDto = new NewDto
                {
                    Author = article.Author,
                    Title = article.Title,
                    Description = article.Description,
                    Content = article.Content,
                    Date = ParsePublishedAt(article.PublishedAt),
                    Url = article.Url,
                    UrlImage = article.UrlToImage
                };

                newsList.Add(newsDto);
            }

            return newsList;
        }

        private static DateTime ParsePublishedAt(string publishedAt)
        {
            DateTime result;

            // Intenta analizar la cadena en formato 'yyyy/MM/dd'
            if (DateTime.TryParseExact(publishedAt, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }

            // Si no se puede analizar, devuelve DateTime.MinValue o maneja el caso según tus necesidades
            return DateTime.MinValue;
        }
    }
}
