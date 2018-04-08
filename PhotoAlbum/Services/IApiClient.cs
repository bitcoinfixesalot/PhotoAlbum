using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
