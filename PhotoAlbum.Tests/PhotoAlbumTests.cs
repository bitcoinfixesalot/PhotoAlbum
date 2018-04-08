using DataTablesParser;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PhotoAlbum.Controllers;
using PhotoAlbum.Data;
using PhotoAlbum.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static PhotoAlbum.Helpers.Constants;

namespace PhotoAlbum.Tests
{
    public class PhotoAlbumTests
    {
        ILogger<HomeController> Logger { get; }

        IDataService DataService { get; }

        IApiClient ApiClient { get; }

        public PhotoAlbumTests()
        {
            var mock = new Mock<ILogger<HomeController>>();
            Logger = mock.Object;

            ApiClient = new ApiClient();
            DataService = new DataService(ApiClient);
        }

        [Fact]
        public async Task GetPhotos()
        {
            var photosTask = await ApiClient.GetAsync<IEnumerable<Photo>>(PHOTOS_URL);

            Assert.NotNull(photosTask);

            var photos = photosTask.Should().BeAssignableTo<IEnumerable<Photo>>().Subject;


            photos.Count().Should().Be(5000);
        }

        [Fact]
        public async Task GetAlbums()
        {
            var albumsTask = await ApiClient.GetAsync<IEnumerable<Album>>(ALBUMS_URL);

            Assert.NotNull(albumsTask);

            var albums = albumsTask.Should().BeAssignableTo<IEnumerable<Album>>().Subject;

            //var movies = okResult.Value.Should().BeAssignableTo<IEnumerable<Photo>>().Subject;

            albums.Count().Should().Be(100);
        }

        [Fact]
        public void GetPhotoAlbumTest()
        {
            HomeController homeController = new HomeController(DataService, Logger);
       
            var form = new FormCollection(TestHelper.Params);

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(context => context.Request.Form).Returns(form);
            homeController.ControllerContext.HttpContext = mockContext.Object;
            var photoAlbumResult = homeController.Data();
            photoAlbumResult.Wait();

            Assert.NotNull(photoAlbumResult);

            var albumJson = photoAlbumResult.Result.Should().BeOfType<JsonResult>().Subject;

            Assert.NotNull(albumJson.Value);
        }
    }
}
