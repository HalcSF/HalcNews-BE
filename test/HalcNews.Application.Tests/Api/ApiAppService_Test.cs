using HalcNews.Noticias;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HalcNews.ApiNews
{
    public class ApiAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly IApiNewsAppService _apiAppService;

        public ApiAppService_Test()
        {
            _apiAppService = GetRequiredService<IApiNewsAppService>();
        }

        [Fact]
        public async Task Should_Search_News()
        {
            //Arrage
            var search = "Apple";

            //Act
            var response = await _apiAppService.Search(search);

            //Assert
            response.ShouldNotBeNull();
            response.Count.ShouldBeGreaterThan(1);
        }

    }
}
