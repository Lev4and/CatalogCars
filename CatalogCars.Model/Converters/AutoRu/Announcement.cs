using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Announcement
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("saleId")]
        public string SaleId { get; set; }

        [JsonProperty("lk_summary")]
        public string Summary { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("color_hex")]
        public string ColorHex { get; set; }

        [JsonProperty("seller_type")]
        public string SellerType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sub_category")]
        public string SubCategory { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("price_info")]
        public Price Price { get; set; }

        [JsonProperty("salon")]
        public Salon Salon { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        [JsonProperty("vehicle_info")]
        public Vehicle Vehicle { get; set; }

        [JsonProperty("documents")]
        public Documents Documents { get; set; }

        [JsonProperty("additional_info")]
        public AdditionalInfo AdditionalInfo { get; set; }
    }
}
