using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class ExternalPanorama
    {
        [JsonProperty("published")]
        public Published Published { get; set; }
    }
}
