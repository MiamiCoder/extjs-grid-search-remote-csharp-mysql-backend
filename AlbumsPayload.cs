using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebUI.Class.Article_Grid.grid_search_remote_csharp_backend
{
    public class AlbumsPayload
    {
        [JsonProperty(propertyName: "albums")]
        public List<Album> Albums { get; set; }
        [JsonProperty(propertyName:"count")]
        public int Count { get; set; }
    }
}