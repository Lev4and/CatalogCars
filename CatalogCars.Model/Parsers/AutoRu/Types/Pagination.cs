using Newtonsoft.Json;

namespace CatalogCars.Model.Parsers.AutoRu.Types
{
    public class Pagination
    {
        [JsonProperty("to")]
        public int To { get; set; }

        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_page_count")]
        public int TotalPageCount { get; set; }

        [JsonProperty("total_offers_count")]
        public int TotalOffersCount { get; set; }
    }
}
