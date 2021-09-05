using CatalogCars.Model.JsonConverters;
using Newtonsoft.Json;
using System;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class AdditionalInfo
    {
        [JsonProperty("creation_date")]
        [JsonConverter(typeof(UnixTimeToDatetimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("update_date")]
        [JsonConverter(typeof(UnixTimeToDatetimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
