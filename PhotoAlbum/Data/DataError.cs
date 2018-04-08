using Newtonsoft.Json;
using System;

namespace PhotoAlbum.Data
{
    public class DataError
    {
        [JsonProperty("error")]
        public String Message { get; set; }
    }
}
