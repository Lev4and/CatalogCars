using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Configuration
    {
        [JsonProperty("doors_count")]
        public int DoorsCount { get; set; }

        [JsonProperty("trunk_volume_min")]
        public int? TrunkVolumeMin { get; set; }

        [JsonProperty("trunk_volume_min")]
        public int? TrunkVolumeMax { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("body_type")]
        public string BodyType { get; set; }

        [JsonProperty("auto_class")]
        public string AutoClass { get; set; }

        [JsonProperty("human_name")]
        public string HumanName { get; set; }

        [JsonProperty("body_type_group")]
        public string BodyTypeGroup { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("main_photo")]
        public MainPhoto MainPhoto { get; set; }
    }
}
