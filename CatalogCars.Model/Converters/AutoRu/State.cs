using CatalogCars.Model.JsonConverters;
using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class State
    {
        [JsonProperty("state_not_beaten")]
        [JsonConverter(typeof(InversionConverter))]
        public bool IsBeaten { get; set; }

        [JsonProperty("mileage")]
        public int Mileage { get; set; }

        [JsonProperty("external_panorama")]
        public ExternalPanorama ExternalPanorama { get; set; }

        [JsonProperty("image_urls")]
        public StatePhoto[] Photos { get; set; }
    }
}
