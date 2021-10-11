using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PricesClient : BaseHttpClient
    {
        public PricesClient() : base("prices/")
        {

        }

        public async Task<HttpResponseMessage> GetMinPriceAsync(Guid currencyId)
        {
            return await _client.PostAsync("minPrice", new StringContent(JsonConvert.SerializeObject(currencyId), 
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxPriceAsync(Guid currencyId)
        {
            return await _client.PostAsync("maxPrice", new StringContent(JsonConvert.SerializeObject(currencyId), 
                Encoding.UTF8, "application/json"));
        }
    }
}
