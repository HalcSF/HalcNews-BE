using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HalcNews.Carpetas
{
    public class FolderAppService_Test : HalcNewsApplicationTestBase
    {
        private readonly IFolderAppService _FolderAppService;

        public FolderAppService_Test()
        {
            _FolderAppService = GetRequiredService<IFolderAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Folders()
        {
            //Arrage

            //Act
            var folderList = await _FolderAppService.GetFolderAsync();

            //Assert
            folderList.ShouldNotBeNull();
            folderList.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Insert_Folder()
        {
            //Arrage
            var folder = new FolderDto
            {
                Name = "Título",
                Description = "Descripción"
            };

            //Act
            await _FolderAppService.InsertFolderAsync(folder);
            var folderResponse = await _FolderAppService.GetFolderAsync();

            //Assert
            folderResponse.ShouldNotBeNull();
            folderResponse.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Get_A_Folder()
        {
            //Arrage

            //Act
            var folderResponse = await _FolderAppService.GetFolderAsync(1);

            //Assert
            folderResponse.ShouldNotBeNull();
        }
    }
}
