//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace HalcNews.ApiNews
//{
//    public class ApiAppService_Test : HalcNewsApplicationTestBase
//    {
//        private readonly IApiNewsAppService _apiAppService;

//        public ApiAppService_Test()
//        {
//            _apiAppService = GetRequiredService<IApiNewsAppService>();
//        }

//        [Fact]
//        public async Task Should_Get_New_Response()
//        {
//            //Arrage


//            //Act
//            var response = await _apiAppService.GetNews("News");

//            //Assert
//            response.ShouldNotBeNull();
//        }

//    }
//}
