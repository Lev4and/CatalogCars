using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Video
    {
        [JsonProperty("full_url")]
        public string FullUrl { get; set; }

        [JsonProperty("low_res_url")]
        public string LowResUrl { get; set; }

        [JsonProperty("high_res_url")]
        public string HighResUrl { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }
    }
}
