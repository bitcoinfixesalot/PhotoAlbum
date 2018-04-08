using Newtonsoft.Json;
using PhotoAlbum.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    public class ApiClient : IApiClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<DataError>(content);
                    throw new Exception(error.Message);
                }

                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
        }
    }
}
