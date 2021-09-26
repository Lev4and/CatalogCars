using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.Types;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.HttpClients
{
    public class CarsHttpClient : BaseHttpClient
    {
        public CarsHttpClient() : base("")
        {

        }

        public string GetUrl(RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            return $"cars/all/do-{rangePrice.To}/?has_image=false&top_days={topDays}&price_from={rangePrice.From}&" +
                $"km_age_from={rangeMileage.From}&km_age_to={rangeMileage.To}&damage_group=ANY&" +
                    $"customs_state_group=DOESNT_MATTER&page_size={pageSize}&sort=cr_date-asc&p={numberPage}";
        }

        public async Task<HttpResponseMessage> GetMainPage()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Cookie", "gradius=1000;gids=");

            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetCars(RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Cookie", "gradius=1000;gids=");

            return await _client.GetAsync(GetUrl(rangeMileage, rangePrice, pageSize, topDays, numberPage));
        }

        public async Task<HttpResponseMessage> GetCountCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            SetAjaxRequestHeaders(headers);

            return await _ajaxClient.PostAsync("listingCount/", new StringContent(JsonConvert.SerializeObject(
                new ParamsAjaxRequestForCars(rangeMileage, rangePrice, pageSize, topDays, numberPage)), Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            SetAjaxRequestHeaders(headers);

            return await _ajaxClient.PostAsync("listing/", new StringContent(JsonConvert.SerializeObject(
                new ParamsAjaxRequestForCars(rangeMileage, rangePrice, pageSize, topDays, numberPage)), Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPriceRanges(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            SetAjaxRequestHeaders(headers);

            return await _ajaxClient.PostAsync("listingPriceRange/", new StringContent(JsonConvert.SerializeObject(
                new ParamsAjaxRequestForCars(rangeMileage, rangePrice, pageSize, topDays, numberPage)), Encoding.UTF8, "application/json"));
        }
    }
}
