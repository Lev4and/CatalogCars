using Newtonsoft.Json;

namespace CatalogCars.Model.Parsers.AutoRu.Types
{
    public class PriceRange
    {
        [JsonProperty("price_to")]
        public int PriceTo { get; set; }

        [JsonProperty("offers_count")]
        public int OffersCount { get; set; }
    }
}
