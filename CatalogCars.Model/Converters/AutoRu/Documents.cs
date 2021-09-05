using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Documents
    {
        [JsonProperty("warranty")]
        public bool? Warranty { get; set; }

        [JsonProperty("pts_original")]
        public bool? PtsOriginal { get; set; }

        [JsonProperty("custom_cleared")]
        public bool? CustomCleared { get; set; }

        [JsonProperty("not_registered_in_russia")]
        public bool? NotRegisteredInRussia { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("owners_number")]
        public int? OwnersNumber { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("pts")]
        public string Pts { get; set; }

        [JsonProperty("license_plate")]
        public string LicensePlate { get; set; }

        [JsonProperty("vin_resolution")]
        public string VinResolution { get; set; }

        [JsonProperty("purchase_date")]
        public PurchaseDate PurchaseDate { get; set; }

        [JsonProperty("warranty_expire")]
        public WarrantyExpire WarrantyExpire { get; set; }
    }
}
