using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Mark
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ru_name")]
        public string RuName { get; set; }

        [JsonProperty("numeric_id")]
        public string NumericId { get; set; }

        [JsonProperty("logo")]
        public MarkLogo Logo { get; set; }
    }
}
