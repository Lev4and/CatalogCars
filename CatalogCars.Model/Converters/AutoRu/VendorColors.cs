using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class VendorColors
    {
        [JsonProperty("main_color")]
        public bool MainColor { get; set; }

        [JsonProperty("body_color_id")]
        public int BodyColorId { get; set; }

        [JsonProperty("mark_color_id")]
        public int MarkColorId { get; set; }

        [JsonProperty("name_ru")]
        public string NameRu { get; set; }

        [JsonProperty("color_type")]
        public string ColorType { get; set; }

        [JsonProperty("hex_codes")]
        public string[] HexCodes { get; set; }

        [JsonProperty("stock_color")]
        public StockColor StockColor { get; set; }

        [JsonProperty("photos")]
        public VendorColorPhoto[] Photos { get; set; }
    }
}
