using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;

namespace CatalogCars.Model.Parsers.AutoRu.Types
{
    public class ParamsAjaxRequestForCars
    {
        [JsonProperty("has_image")]
        public bool HasImage { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("km_age_to")]
        public double KmAgeTo { get; set; }

        [JsonProperty("price_to")]
        public double PriceTo { get; set; }

        [JsonProperty("price_from")]
        public double PriceFrom { get; set; }

        [JsonProperty("km_age_from")]
        public double KmAgeFrom { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("top_days")]
        public string TopDays { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("output_type")]
        public string OutputType { get; set; }

        [JsonProperty("damage_group")]
        public string DamageGroup { get; set; }

        [JsonProperty("customs_state_group")]
        public string CustomsStateGroup { get; set; }

        public ParamsAjaxRequestForCars(RangeMileage rangeMileage, RangePrice rangePrice,  int topDays, int numberPage)
        {
            HasImage = false;

            Page = numberPage;

            KmAgeTo = rangeMileage.To;
            KmAgeFrom = rangeMileage.From;

            PriceTo = rangePrice.To;
            PriceFrom = rangePrice.From;

            Sort = "cr_date-asc";

            Section = "all";
            Category = "cars";
            DamageGroup = "ANY";
            OutputType = "table";
            TopDays = $"{topDays}";
            CustomsStateGroup = "DOESNT_MATTER";
        }
    }
}
