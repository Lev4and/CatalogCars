using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Sizes
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("thumb_m")]
        public string ThumbM { get; set; }

        [JsonProperty("320x240")]
        public string Resolution320x240 { get; set; }

        [JsonProperty("456x342")]
        public string Resolution456x342 { get; set; }

        [JsonProperty("456x342n")]
        public string Resolution456x342n { get; set; }

        [JsonProperty("1200x900")]
        public string Resolution1200x900 { get; set; }

        [JsonProperty("1200x900n")]
        public string Resolution1200x900n { get; set; }
    }
}
