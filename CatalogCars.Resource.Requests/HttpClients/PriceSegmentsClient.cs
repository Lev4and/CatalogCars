using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PriceSegmentsClient : BaseHttpClient
    {
        public PriceSegmentsClient() : base("priceSegments/")
        {

        }

        public async Task<HttpResponseMessage> GetCountPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesPriceSegmentsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPriceSegmentsAsync()
        {
            return await _client.GetAsync("");
        }
    }
}
