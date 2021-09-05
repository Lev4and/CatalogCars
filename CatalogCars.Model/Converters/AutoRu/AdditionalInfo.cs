using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class AdditionalInfo
    {
        [JsonProperty("creation_date")]
        public int CreatedAt { get; set; }

        [JsonProperty("update_date")]
        public int UpdatedAt { get; set; }
    }
}
