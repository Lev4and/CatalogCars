using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class StatusesClient : BaseHttpClient
    {
        public StatusesClient() : base("statuses/")
        {

        }

        public async Task<HttpResponseMessage> GetCountStatusesAsync(StatusesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesStatusesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetStatusesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetStatusesAsync(StatusesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }
    }
}
