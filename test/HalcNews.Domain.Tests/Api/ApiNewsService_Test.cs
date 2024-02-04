﻿using HalcNews.ApiNews;
using HalcNews.Estadisticas;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HalcNews.Api
{
    public class ApiNewsService_Test
    {
        private readonly ApiNewsService _apiNewsService;
        IStatsAppService statsAppService;

        public ApiNewsService_Test()
        {
            _apiNewsService = new ApiNewsService(statsAppService);
        }
        [Fact]
        public async Task Should_Get_All_News()
        {
            //Arrage
            var query = "Apple";

            //Act
            var articles = await _apiNewsService.GetNewsAsync(query);

            //Assert
            articles.ShouldNotBeNull();
            articles.Count.ShouldBeGreaterThan(1);
        }
    }
}
