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

        public string GetUrl(RangeMileage rangeMileage, RangePrice rangePrice, int topDays, int numberPage)
        {
            return $"cars/all/do-{rangePrice.To}/?has_image=false&top_days={topDays}&price_from={rangePrice.From}&" +
                $"km_age_from={rangeMileage.From}&km_age_to={rangeMileage.To}&damage_group=ANY&" +
                    $"customs_state_group=DOESNT_MATTER&sort=cr_date-asc&p={numberPage}";
        }

        public async Task<HttpResponseMessage> GetCars(RangeMileage rangeMileage, RangePrice rangePrice,  int topDays, int numberPage)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Cookie", "gradius=1000;gids=");

            return await _client.GetAsync(GetUrl(rangeMileage, rangePrice, topDays, numberPage));
        }

        public async Task<HttpResponseMessage> GetCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int topDays, int numberPage)
        {
            if(headers != null)
            {
                _ajaxClient.DefaultRequestHeaders.Clear();

                _ajaxClient.DefaultRequestHeaders.Add("Host", "auto.ru");
                _ajaxClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                _ajaxClient.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not; A Brand\";v=\"99\", \"Yandex\";v=\"91\", \"Chromium\";v=\"91\"");
                _ajaxClient.DefaultRequestHeaders.Add("x-csrf-token", headers.CsrfToken);
                _ajaxClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                _ajaxClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 YaBrowser/21.6.4.787 Yowser/2.5 Safari/537.36");
                _ajaxClient.DefaultRequestHeaders.Add("x-requested-with", "fetch");
                _ajaxClient.DefaultRequestHeaders.Add("Accept", "*/*");
                _ajaxClient.DefaultRequestHeaders.Add("Origin", "https://auto.ru");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "same-origin");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                _ajaxClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                _ajaxClient.DefaultRequestHeaders.Add("Accept-Language", "ru,en;q=0.9");
                _ajaxClient.DefaultRequestHeaders.Add("Cookie", headers.CookieContent);
            }

            return await _ajaxClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(
                new ParamsAjaxRequestForCars(rangeMileage, rangePrice, topDays, numberPage)), Encoding.UTF8, "application/json"));
        }
    }
}
