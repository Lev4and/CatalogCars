using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PtsClient : BaseHttpClient
    {
        public PtsClient() : base("pts/")
        {

        }

        public async Task<HttpResponseMessage> GetMinOwnersNumberAsync()
        {
            return await _client.PostAsync("minOwnersNumber", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxOwnersNumberAsync()
        {
            return await _client.PostAsync("maxOwnersNumber", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
