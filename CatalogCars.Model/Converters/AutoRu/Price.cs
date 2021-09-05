using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Price
    {
        [JsonProperty("with_nds")]
        public bool WithNds { get; set; }

        [JsonProperty("price")]
        public double Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
