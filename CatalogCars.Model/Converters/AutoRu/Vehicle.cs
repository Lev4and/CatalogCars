using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Vehicle
    {
        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("steering_wheel")]
        public string SteeringWheel { get; set; }

        [JsonProperty("mark_info")]
        public Mark Mark { get; set; }

        [JsonProperty("model_info")]
        public Model Model { get; set; }

        [JsonProperty("super_gen")]
        public Generation Generation { get; set; }

        [JsonProperty("configuration")]
        public Configuration Configuration { get; set; }

        [JsonProperty("complectation")]
        public Complectation Complectation { get; set; }

        [JsonProperty("tech_param")]
        public TechnicalParameters TechnicalParameters { get; set; }
    }
}
