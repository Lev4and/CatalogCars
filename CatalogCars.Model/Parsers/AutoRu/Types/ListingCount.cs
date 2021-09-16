using Newtonsoft.Json;

namespace CatalogCars.Model.Parsers.AutoRu.Types
{
    public class ListingCount
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
