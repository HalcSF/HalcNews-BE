using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalcNews.Busqueda;
using HalcNews.ListaNoticias;
using HalcNews.News;
using HalcNews.NewsList;
using HalcNews.Alertas;
using Shouldly;
using Xunit;

namespace HalcNews.Search
{

    public class SearchAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly ISearchAppService _SearchAppService;
        private readonly INewsListAppService _NewsListAppService;
        private readonly INewAppService _NewAppService;
        private readonly IAlertAppService _AlertAppService;

        public SearchAppService_Test()
        {
            _SearchAppService = GetRequiredService<ISearchAppService>();
            _NewsListAppService = GetRequiredService<INewsListAppService>();
            _NewAppService = GetRequiredService<INewAppService>();
            _AlertAppService = GetRequiredService<IAlertAppService>();
        }

        [Fact]
        public async Task Should_Search_News()
        {
            //Arrage
            var search = "Apple";

            //Act
            var response = await _SearchAppService.SearchNews(search);

            //Assert
            response.ShouldNotBeNull();
            response.Keyword.ShouldBe(search);
            response.News.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Should_SaveSearch()
        {
            
            var newsListList = await _NewsListAppService.GetNewsListAsync();
            var firstNewsList = newsListList.FirstOrDefault();

            // Realiza la búsqueda de noticias
            var search = await _SearchAppService.SearchNews("Apple");

            // Act
            await _SearchAppService.SaveSearch(firstNewsList, search);
            

            firstNewsList.News.Count.ShouldBeGreaterThan(0);

        }

        [Fact]
        public async Task Should_Add_Alert()
        {
            //Arrage
            var keyword = "Apple";

            //Act
            await _SearchAppService.AddAlert(keyword);
            var response = await _AlertAppService.GetAlertAsync(1);

            //Assert
            response.ShouldNotBeNull();
            response.Search.ShouldBe(keyword);
            response.isActive.ShouldBeTrue();
        }

    }
}