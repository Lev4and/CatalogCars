using Newtonsoft.Json;
using System;

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

        public DateTime? GetFormattedPurchaseDate()
        {
            if(PurchaseDate != null)
            {
                if(PurchaseDate.Month != null)
                {
                    if(PurchaseDate.Day != null)
                    {
                        return new DateTime((int)PurchaseDate.Year, (int)PurchaseDate.Month, (int)PurchaseDate.Day);
                    }

                    return new DateTime((int)PurchaseDate.Year, (int)PurchaseDate.Month, 1);
                }

                return new DateTime((int)PurchaseDate.Year, 1, 1);
            }

            return null;
        }

        public DateTime? GetFormattedWarrantyExpire()
        {
            if (WarrantyExpire != null)
            {
                if (WarrantyExpire.Month != null)
                {
                    if (WarrantyExpire.Day != null)
                    {
                        return new DateTime((int)WarrantyExpire.Year, (int)WarrantyExpire.Month, (int)WarrantyExpire.Day);
                    }

                    return new DateTime((int)WarrantyExpire.Year, (int)WarrantyExpire.Month, 1);
                }

                return new DateTime((int)WarrantyExpire.Year, 1, 1);
            }

            return null;
        }
    }
}
