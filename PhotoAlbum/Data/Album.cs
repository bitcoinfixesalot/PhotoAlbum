﻿using Newtonsoft.Json;

namespace PhotoAlbum.Data
{
    public class Album
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
