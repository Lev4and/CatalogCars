using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Coordinate
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
