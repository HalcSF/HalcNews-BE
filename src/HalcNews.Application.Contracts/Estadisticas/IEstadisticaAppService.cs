using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcNews.Estadisticas
{
    public interface IStatsAppService
    {
        Task<ICollection<StatsDto>> GetStatsAsync();
        Task InsertStatsAsync(StatsDto stats);
        Task<double> AverageResponseTime();
        Task<int> AverageNumArticles();
        Task<int> AverageNumArticlesWithImages();
        Task<List<WordFrequency>> MostSearchedWords(int n);
    }
}
