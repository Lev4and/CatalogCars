using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PriceSegmentsClient : BaseHttpClient
    {
        public PriceSegmentsClient() : base("priceSegments")
        {

        }

        public async Task<HttpResponseMessage> GetPriceSegmentsAsync()
        {
            return await _client.PostAsync("", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
