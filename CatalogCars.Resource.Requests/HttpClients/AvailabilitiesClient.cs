using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class AvailabilitiesClient : BaseHttpClient
    {
        public AvailabilitiesClient() : base("availabilities/")
        {

        }

        public async Task<HttpResponseMessage> GetCountAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesAvailabilitiesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetAvailabilitiesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }
    }
}
