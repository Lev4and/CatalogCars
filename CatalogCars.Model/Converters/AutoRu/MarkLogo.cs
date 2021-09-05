using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class MarkLogoSizes
    {
        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("big-logo")]
        public string BigLogo { get; set; }

        [JsonProperty("black-logo")]
        public string BlackLogo { get; set; }
    }

    public class MarkLogo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sizes")]
        public MarkLogoSizes Sizes { get; set; }
    }
}
