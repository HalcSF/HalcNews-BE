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
using HalcNews.Carpetas;
using Shouldly;
using Xunit;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace HalcNews.Search
{

    public class SearchAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly ISearchAppService _SearchAppService;
        private readonly INewsListAppService _NewsListAppService;
        private readonly INewAppService _NewAppService;
        private readonly IAlertAppService _AlertAppService;
        private readonly IFolderAppService _FolderAppService;

        public SearchAppService_Test()
        {
            _SearchAppService = GetRequiredService<ISearchAppService>();
            _NewsListAppService = GetRequiredService<INewsListAppService>();
            _NewAppService = GetRequiredService<INewAppService>();
            _AlertAppService = GetRequiredService<IAlertAppService>();
            _FolderAppService = GetRequiredService<IFolderAppService>();
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
            // Obtenemos la carpeta a la cual le vamos a agregar una alerta
            var folder = await _FolderAppService.GetFolderAsync(1);

            // Agregamos la alerta
            await _SearchAppService.AddAlert(folder, keyword);

            var alerta = folder.Alerts.Last();

            //Assert
            folder.ShouldNotBeNull();
            folder.Name.ShouldBe("CarpetaAlerta");
            alerta.Search.ShouldBe(keyword);

        }

        [Fact]
        public async Task Should_Add_New_In_Folder()
        {
            //Arrage
            var newE = new NewDto
            {
                Author = "Tobias Grandi",
                Title = "TituloEjemplo",
                Description = "DescripcionEjemplo",
                Content = "ContentEjemplo",
                Date = DateTime.Now,
                Url = "URL",
                UrlImage = "URLimage"
            };

            var folder = await _FolderAppService.GetFolderAsync(1);
            //Act
            await _SearchAppService.AddNewInFolder(folder, newE);

            //Assert
            folder.ShouldNotBeNull();
            folder.Name.ShouldBe("CarpetaAlerta");
            folder.News.ShouldNotBeEmpty();
            folder.News.FirstOrDefault().Author.ShouldBe("Tobias Grandi");
        }

    }
}