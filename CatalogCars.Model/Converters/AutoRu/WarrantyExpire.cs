using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class WarrantyExpire
    {
        [JsonProperty("day")]
        public int? Day { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }
    }
}
