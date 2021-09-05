using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Model
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ru_name")]
        public string RuName { get; set; }
    }
}
