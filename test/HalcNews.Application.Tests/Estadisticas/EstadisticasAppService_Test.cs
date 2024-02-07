using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HalcNews.ApiNews;
using AutoMapper;
using Azure;
using Shouldly;

namespace HalcNews.Estadisticas
{
    public class StatsAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly IStatsAppService _statsAppService;
        private readonly IApiNewsAppService _apiAppService;

        public StatsAppService_Test()
        {
            _statsAppService = GetRequiredService<IStatsAppService>();
            _apiAppService = GetRequiredService<IApiNewsAppService>();
        }

        [Fact]

        public async Task Should_Get_All_Stats()
        {
            await _apiAppService.Search("Apple");
            await _apiAppService.Search("Orange");
            await _apiAppService.Search("Banana");
            await _apiAppService.Search("Tomatoe");

            var stats = await _statsAppService.GetStatsAsync();

            stats.ShouldNotBeNull();
            stats.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Should_Insert_Stats()
        {
            var newStat = new StatsDto
            {
                Date = DateTime.Now,
                ResponseTime = 200,
                TotalArticles = 10,
                ArticlesWithImages = 4,
                Search = "Microsoft"
            };

            await _statsAppService.InsertStatsAsync(newStat);

            var stats = await _statsAppService.GetStatsAsync();

            stats.ShouldNotBeNull();
            stats.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_Average_Response_Time()
        {
            await _apiAppService.Search("Apple");
            await _apiAppService.Search("Orange");
            await _apiAppService.Search("Banana");
            await _apiAppService.Search("Tomatoe");

            var stats = await _statsAppService.GetStatsAsync();
            double totalResponseTime = stats.Sum(s => s.ResponseTime);
            double countStats = stats.Count;
            double manualAvResponseTime = totalResponseTime / countStats;

            double avResponseTime = await _statsAppService.AverageResponseTime();

            avResponseTime.ShouldBe(manualAvResponseTime);
        }

        [Fact]
        public async Task Should_Get_Average_Num_Articles()
        {
            await _apiAppService.Search("Apple");
            await _apiAppService.Search("Orange");
            await _apiAppService.Search("Banana");
            await _apiAppService.Search("Tomatoe");

            var stats = await _statsAppService.GetStatsAsync();
            int totalArticles = stats.Sum(s => s.TotalArticles);
            int countStats = stats.Count;
            int manualAvNumArticles = totalArticles / countStats;

            int avNumArticles = await _statsAppService.AverageNumArticles();

            avNumArticles.ShouldBe(manualAvNumArticles);
        }

        [Fact]
        public async Task Should_Get_Average_Num_Articles_With_Images()
        {
            await _apiAppService.Search("Apple");
            await _apiAppService.Search("Orange");
            await _apiAppService.Search("Banana");
            await _apiAppService.Search("Tomatoe");

            var stats = await _statsAppService.GetStatsAsync();
            int articlesWithImages = stats.Sum(s => s.ArticlesWithImages);
            int countStats = stats.Count;
            int manualAvNumArticlesWithImages = articlesWithImages / countStats;

            int avNumArticles = await _statsAppService.AverageNumArticlesWithImages();

            avNumArticles.ShouldBe(manualAvNumArticlesWithImages);
        }

        [Fact]
        public async Task Should_Get_Most_Searched_Words()
        {

            List<string> searchs = [
                "Apple 2024", "Apple USA", "Is the orange orange?", "Is the apple angry?",
                "Sweet apple", "Happy apple", "Monky eating a banana", "Cherry tomatoe", "Green tomatoe",
                "Tomatoe recipies", "Tomatoe", "Orange"
            ];

            foreach (var search in searchs)
            {
                await _apiAppService.Search(search);
            }

            var firstWordFrequency = new WordFrequency
            {
                Word = "apple",
                Frequency = 5
            };
            var secondWordFrequency = new WordFrequency
            {
                Word = "tomatoe",
                Frequency = 4
            };
            var thirdWordFrequency = new WordFrequency
            {
                Word = "orange",
                Frequency = 3
            };

            List<WordFrequency> expectedWordFrequencyList =
            [
                firstWordFrequency,
                secondWordFrequency,
                thirdWordFrequency,
            ];

            List<WordFrequency> threeMostSearchedWords = await _statsAppService.MostSearchedWords(3);
            List<WordFrequency> seventeenMostSearchedWords = await _statsAppService.MostSearchedWords(20);//Existen 17 únicas palabras,
                                                                                                        //al pasar 20 como parámetro
                                                                                                        //debería devolver solo 17

            var expectedWords = expectedWordFrequencyList.Select(word => word.Word).ToList();
            var realWords = threeMostSearchedWords.Select(word => word.Word).ToList();
            realWords.ShouldBe(expectedWords);

            var expectedFrequency = expectedWordFrequencyList.Select(f => f.Frequency).ToList();
            var realFrequency = threeMostSearchedWords.Select(f => f.Frequency).ToList();
            realFrequency.ShouldBe(expectedFrequency);

            seventeenMostSearchedWords.Count.ShouldBe(17);
        }

        [Fact]
        public async Task Should_Get_Day_With_Most_Searches()
        {
            var stat1 = new StatsDto
            {
                Date = new DateTime(2024, 3, 2),
                ResponseTime = 0,
                TotalArticles = 0,
                ArticlesWithImages = 0,
                Search = ""
            };

            var stat2 = new StatsDto
            {
                Date = new DateTime(2024, 1, 5),
                ResponseTime = 0,
                TotalArticles = 0,
                ArticlesWithImages = 0,
                Search = ""
            };

            var stat3 = new StatsDto
            {
                Date = new DateTime(2024, 3, 2),
                ResponseTime = 0,
                TotalArticles = 0,
                ArticlesWithImages = 0,
                Search = ""
            };

            var stat4 = new StatsDto
            {
                Date = new DateTime(2023, 7, 4),
                ResponseTime = 0,
                TotalArticles = 0,
                ArticlesWithImages = 0,
                Search = ""
            };

            await _statsAppService.InsertStatsAsync(stat1);
            await _statsAppService.InsertStatsAsync(stat2);
            await _statsAppService.InsertStatsAsync(stat3);
            await _statsAppService.InsertStatsAsync(stat4);

            var dayWithMostSearches = await _statsAppService.GetDayWithMostSearches();

            dayWithMostSearches.ShouldBe(new DateTime(2024, 3, 2));
        }

        [Fact]
        public async Task Should_Throw_Exception()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _statsAppService.AverageResponseTime();
                await _statsAppService.AverageNumArticles();
                await _statsAppService.AverageNumArticlesWithImages();
            });
        }
        [Fact]
        public async Task Should_Not_Get_Most_Searched_Words()
        {
            List<WordFrequency> wordFrequencyList = await _statsAppService.MostSearchedWords(34);
            wordFrequencyList.Count.ShouldBe(0);
        }
    }
}
