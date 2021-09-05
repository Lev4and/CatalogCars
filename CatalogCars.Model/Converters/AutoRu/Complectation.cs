using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Complectation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("available_options")]
        public string[] Options { get; set; }

        [JsonProperty("vendor_colors")]
        public VendorColors[] VendorColors { get; set; }
    }
}
