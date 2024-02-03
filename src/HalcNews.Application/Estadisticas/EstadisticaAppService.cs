using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Logging;


namespace HalcNews.Estadisticas
{
    public class StatsAppService : HalcNewsAppService, IStatsAppService
    {
        private readonly IRepository<Stats, int> _repository;

        public StatsAppService(IRepository<Stats, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<StatsDto>> GetStatsAsync()
        {
            var stats = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<Stats>, ICollection<StatsDto>>(stats);
        }

        public async Task InsertStatsAsync(StatsDto stats)
        {
            var statsMapped = ObjectMapper.Map<StatsDto, Stats>(stats);

            await _repository.InsertAsync(statsMapped);
        }

        //TIEMPO PROMEDIO DE RESPUESTA
        public async Task<double> GetTotalResponseTime()
        {
            var stats = await GetStatsAsync();

            return stats.Sum(s => s.ResponseTime);
        }

        public async Task<int> CountStats()
        {
            return await _repository.CountAsync();
        }

        public async Task<double> AverageResponseTime()
        {
            double totalResponseTime = await GetTotalResponseTime();
            double statsCount = await CountStats();

            if (statsCount == 0)
            {
                // Manejar la división por cero según tu lógica (por ejemplo, devolver un valor predeterminado o lanzar una excepción).
                throw new InvalidOperationException("No se han realizado consultas a la API.");
            }

            return totalResponseTime / statsCount;
        }

        //CANTIDAD DE ARTICULOS PROMEDIOS DEVUELTOS POR LLAMADA
        public async Task<int> GetTotalArticles()
        {
            var stats = await GetStatsAsync();

            return stats.Sum(s => s.TotalArticles);
        }

        public async Task<int> AverageNumArticles()
        {
            int totalArticles = await GetTotalArticles();
            int statsCount = await CountStats();

            if (statsCount == 0)
            {
                // Manejar la división por cero según tu lógica (por ejemplo, devolver un valor predeterminado o lanzar una excepción).
                throw new InvalidOperationException("No se han realizado consultas a la API.");
            }

            return totalArticles / statsCount;
        }

        //CANTIDAD DE ARTICULOS CON IMÁGENES DEVUELTOS POR LLAMADA
        public async Task<int> GetTotalArticlesWithImages()
        {
            var stats = await GetStatsAsync();

            return stats.Sum(s => s.ArticlesWithImages);
        }

        public async Task<int> AverageNumArticlesWithImages()
        {
            int totalArticles = await GetTotalArticlesWithImages();
            int statsCount = await CountStats();

            if (statsCount == 0)
            {
                // Manejar la división por cero según tu lógica (por ejemplo, devolver un valor predeterminado o lanzar una excepción).
                throw new InvalidOperationException("No se han realizado consultas a la API.");
            }

            return totalArticles / statsCount;
        }

        //PALABRAS MÁS BUSCADAS

        public async Task<List<string>> GetSearches()
        {
            var stats = await GetStatsAsync();

            return stats.Select(s => s.Search).ToList();
        }

        public static List<string> NormalizeWords(List<string> searches)
        {
            //Separa las búsquedas en palabras individuales en minúscula
            return searches
                .SelectMany(search => (search ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(word => word.ToLower())
                .ToList();
        }

        public static List<WordFrequency> CountWordFrequency(List<string> words)
        {
            //Asocia cada palabra con su frecuencia de búsqueda y devuelve una lista ordenada por frecuencia de forma descendiente
            return words
                .GroupBy(word => word)
                .Select(group => new WordFrequency { Word = group.Key, Frequency = group.Count() })
                .OrderByDescending(word => word.Frequency)
                .ToList();
        }

        public async Task<List<WordFrequency>> MostSearchedWords(int n)
        {
            //Devuelve las n palabras más buscadas, junto con su frecuencia
            var searches = await GetSearches();
            var normalizedSearches = NormalizeWords(searches);
            var wordFrequency = CountWordFrequency(normalizedSearches);

            return wordFrequency.Take(n).ToList();
        }

        //DÍA QUE MÁS BÚSQUEDAS SE REALIZARON

        public async Task<DateTime> GetDayWithMostSearches()
        {
            var stats = await GetStatsAsync();

            var daySearchCounts = stats.GroupBy(s => s.Date.Date)
                              .Select(g => new { Date = g.Key, SearchCount = g.Count() })
                              .OrderByDescending(g => g.SearchCount)
                              .FirstOrDefault();

            return daySearchCounts?.Date ?? DateTime.MinValue;
        }
    }
}
