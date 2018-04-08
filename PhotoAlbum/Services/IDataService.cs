using PhotoAlbum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    public interface IDataService
    {
        Task<List<PhotoAlbumModel>> GetPhotosAsync(); 
    }
}
