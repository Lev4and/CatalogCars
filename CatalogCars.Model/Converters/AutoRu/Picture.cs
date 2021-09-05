using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Picture
    {
        [JsonProperty("full_first_frame")]
        public string FullFirstFrame { get; set; }

        [JsonProperty("high_res_first_frame")]
        public string HighResFirstFrame { get; set; }

        [JsonProperty("preview_first_frame")]
        public string PreviewFirstFrame { get; set; }
    }
}
