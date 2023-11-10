using HalcNews.ListaNoticias;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
    }
}
