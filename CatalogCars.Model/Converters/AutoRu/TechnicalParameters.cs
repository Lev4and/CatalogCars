using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class TechnicalParameters
    {
        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("power_kvt")]
        public int PowerKvt { get; set; }

        [JsonProperty("displacement")]
        public int Displacement { get; set; }

        [JsonProperty("clearance_min")]
        public int ClearanceMin { get; set; }

        [JsonProperty("fuel_rate")]
        public double? FuelRate { get; set; }

        [JsonProperty("acceleration")]
        public double Acceleration { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gear_type")]
        public string GearType { get; set; }

        [JsonProperty("human_name")]
        public string HumanName { get; set; }

        [JsonProperty("nameplate")]
        public string Nameplate { get; set; }

        [JsonProperty("engine_type")]
        public string EngineType { get; set; }

        [JsonProperty("transmission")]
        public string Transmission { get; set; }
    }
}
