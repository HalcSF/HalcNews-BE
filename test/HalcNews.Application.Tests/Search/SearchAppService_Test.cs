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
            var folderId = await _FolderAppService.GetFolderAsync(1);
            await _SearchAppService.AddAlert(folderId.Id, keyword);
            var response = await _AlertAppService.GetAlertAsync(1);
            var folderId2 = await _FolderAppService.GetFolderAsync(response.FolderId);

            //Assert
            response.ShouldNotBeNull();
            response.Search.ShouldBe(keyword);
            response.isActive.ShouldBeTrue();
            response.FolderId.ShouldBe(1);
            folderId2.Name.ShouldBe("CarpetaAlerta");
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

            //Act
            await _SearchAppService.AddNewInFolder(1,newE);
            var response = await _FolderAppService.GetFolderAsync(1);
            

            //Assert
            response.ShouldNotBeNull();
            response.Name.ShouldBe("CarpetaAlerta");
            response.News.ShouldNotBeEmpty();
            response.News.FirstOrDefault().Author.ShouldBe("Author");
        }

    }
}