using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class MainPhotoSizes
    {
        [JsonProperty("orig")]
        public string Original { get; set; }

        [JsonProperty("cattouch")]
        public string Cattouch { get; set; }

        [JsonProperty("wizardv3mr")]
        public string Wizardv3mr { get; set; }
    }

    public class MainPhoto
    {
        [JsonProperty("sizes")]
        public MainPhotoSizes Sizes { get; set; }
    }
}
