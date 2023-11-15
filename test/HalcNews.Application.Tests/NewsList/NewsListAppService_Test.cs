using HalcNews.ListaNoticias;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HalcNews.NewsList
{
    public class NewsListAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly INewsListAppService _NewsListAppService;

        public NewsListAppService_Test()
        {
            _NewsListAppService = GetRequiredService<INewsListAppService>();
        }

        [Fact]
        public async Task Should_Get_All_NewsList()
        {
            //Arrage

            //Act
            var newsList = await _NewsListAppService.GetNewsListAsync();

            //Assert
            newsList.ShouldNotBeNull();
            newsList.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Insert_NewsList()
        {
            //Arrage
            var newsList = new NewsListDto
            {
                Date = DateTime.Now,
                Title = "Título",
                Description = "Descripción"
            };

            //Act
            await _NewsListAppService.InsertNewsListAync(newsList);

            //Assert
            var newsListResponse = await _NewsListAppService.GetNewsListAsync();
            newsListResponse.ShouldNotBeNull();
            newsListResponse.Count.ShouldBe(2);
        }


        [Fact]
        public async Task Should_Update()
        {
            //Arrage
            var newsListResponse = await _NewsListAppService.GetNewsListAsync(1);

            //Act
            newsListResponse.Title.ShouldBe("Título");
            newsListResponse.Title = "Título2";

            //Assert
            await _NewsListAppService.UpdateNewsListAync(newsListResponse);

            newsListResponse.Title.ShouldBe("Título2");
        }

    }
}
