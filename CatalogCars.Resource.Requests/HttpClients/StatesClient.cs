using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class StatesClient : BaseHttpClient
    {
        public StatesClient() : base("states/")
        {

        }

        public async Task<HttpResponseMessage> GetMinMileageAsync()
        {
            return await _client.PostAsync("minMileage", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxMileageAsync()
        {
            return await _client.PostAsync("maxMileage", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
