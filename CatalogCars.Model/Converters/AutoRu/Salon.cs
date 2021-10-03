using Newtonsoft.Json;
using System;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Salon
    {
        [JsonProperty("is_oficial")]
        public bool? IsOfficial { get; set; }

        [JsonProperty("actual_stock")]
        public bool? ActualStock { get; set; }

        [JsonProperty("loyalty_program")]
        public bool? LoyaltyProgram { get; set; }

        [JsonProperty("salon_id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("dealer_id")]
        public string DealerId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }
}
