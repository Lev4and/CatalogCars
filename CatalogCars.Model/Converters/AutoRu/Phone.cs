using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Phone
    {
        [JsonProperty("phone")]
        public string Value { get; set; }
    }
}
