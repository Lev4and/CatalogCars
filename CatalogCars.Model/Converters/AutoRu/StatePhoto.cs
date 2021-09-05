using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class StatePhoto
    {
        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("photo_class")]
        public string PhotoClass { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }
    }
}
