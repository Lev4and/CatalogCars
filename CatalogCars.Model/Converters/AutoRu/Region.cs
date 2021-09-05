using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Region
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dative")]
        public string Dative { get; set; }

        [JsonProperty("genitive")]
        public string Genitive { get; set; }

        [JsonProperty("id")]
        public string StringId { get; set; }

        [JsonProperty("accusative")]
        public string Accusative { get; set; }

        [JsonProperty("preposition")]
        public string Preposition { get; set; }

        [JsonProperty("prepositional")]
        public string Prepositional { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("parent_ids")]
        public string[] ParentIds { get; set; }
    }
}
