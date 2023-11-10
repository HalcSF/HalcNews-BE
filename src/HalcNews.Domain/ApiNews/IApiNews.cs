using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.ApiNews
{
        public interface IApiNews
        {
        Task<ICollection<ArticleDto>> GetNewsAsync(string? Search);
        }
    }