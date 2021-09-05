using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Generation
    {
        [JsonProperty("year_from")]
        public int YearFrom { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ru_name")]
        public string RuName { get; set; }

        [JsonProperty("price_segment")]
        public string PriceSegment { get; set; }
    }
}
