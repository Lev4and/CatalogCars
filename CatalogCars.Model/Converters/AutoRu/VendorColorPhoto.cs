using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class VendorColorPhotoSizes
    {
        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("orig")]
        public string Orig { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("thumb_s")]
        public string ThumbS { get; set; }

        [JsonProperty("thumb_m")]
        public string ThumbM { get; set; }

        [JsonProperty("auto_main")]
        public string AutoMain { get; set; }

        [JsonProperty("thumb_s_2x")]
        public string ThumbS2x { get; set; }

        [JsonProperty("cattouch")]
        public string Cattouch { get; set; }

        [JsonProperty("wizardv3")]
        public string Wizardv3 { get; set; }

        [JsonProperty("islandoff")]
        public string IslandOff { get; set; }

        [JsonProperty("wizardv3mr")]
        public string Wizardv3mr { get; set; }

        [JsonProperty("92x69")]
        public string Resolution92x69 { get; set; }

        [JsonProperty("120x90")]
        public string Resolution120x90 { get; set; }

        [JsonProperty("320x240")]
        public string Resolution320x240 { get; set; }

        [JsonProperty("456x342")]
        public string Resolution456x342 { get; set; }

        [JsonProperty("832x624")]
        public string Resolution832x624 { get; set; }

        [JsonProperty("1200x900")]
        public string Resolution1200x900 { get; set; }

        [JsonProperty("1200x900n")]
        public string Resolution1200x900n { get; set; }
    }

    public class VendorColorPhoto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sizes")]
        public VendorColorPhotoSizes Sizes { get; set; }
    }
}
