using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Place
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("geobase_id")]
        public string GeobaseId { get; set; }

        [JsonProperty("region_info")]
        public Region Region { get; set; }

        [JsonProperty("coord")]
        public Coordinate Coordinate { get; set; }
    }
}
