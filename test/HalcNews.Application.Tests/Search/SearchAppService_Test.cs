using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalcNews.Busqueda;
using HalcNews.News;
using HalcNews.NewsList;
using Shouldly;
using Xunit;

namespace HalcNews.Search
{

    public class SearchAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly ISearchAppService _SearchAppService;
        private readonly INewsListAppService _NewsListAppService;
        private readonly INewAppService _NewAppService;

        public SearchAppService_Test()
        {
            _SearchAppService = GetRequiredService<ISearchAppService>();
            _NewsListAppService = GetRequiredService<INewsListAppService>();
            _NewAppService = GetRequiredService<INewAppService>();
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
            //Arrage
            var search = await _SearchAppService.SearchNews("Apple");
            var newsList = await _NewsListAppService.GetNewsListAsync(1);
           
            //Act
            await _SearchAppService.SaveSearch(newsList, search);
            var response = await _NewAppService.GetNewsAsync();

            //Assert
            response.ShouldBeEmpty();

            
        }

    }
}