using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Seller
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public Place Location { get; set; }

        [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }
}
