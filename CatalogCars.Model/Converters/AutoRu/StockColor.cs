using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class StockColor
    {
        [JsonProperty("name_ru")]
        public string NameRu { get; set; }

        [JsonProperty("hex_code")]
        public string HexCode { get; set; }
    }
}
