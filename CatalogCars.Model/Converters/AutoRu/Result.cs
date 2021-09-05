using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Result
    {
        [JsonProperty("offers")]
        public Announcement[] Announcements { get; set; }
    }
}
