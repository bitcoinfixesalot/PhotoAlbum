using PhotoAlbum.Data;
using PhotoAlbum.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PhotoAlbum.Helpers.Constants;

namespace PhotoAlbum.Services
{
    public class DataService : IDataService
    {
        public DataService(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public IApiClient ApiClient { get; }

        public async Task<List<PhotoAlbumModel>> GetPhotosAsync()
        {
            var photos = await ApiClient.GetAsync<IEnumerable<Photo>>(PHOTOS_URL);
            var albums = await ApiClient.GetAsync<IEnumerable<Album>>(ALBUMS_URL);

            var photoAlbums = from p in photos
                              join a in albums on p.AlbumId equals a.Id
                              select new PhotoAlbumModel
                              {
                                  Id = p.Id,
                                  AlbumId = a.Id,
                                  AlbumTitle = a.Title,
                                  PhotoTitle = p.Title,
                                  UserId = a.UserId,
                                  ThumbnailUrl = p.ThumbnailUrl,
                                  Url = p.Url };

            return photoAlbums.ToList();
        }
    }
}
