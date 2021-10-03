using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SalonsClient : BaseHttpClient
    {
        public SalonsClient() : base("salons/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSalonsAsync(SalonsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinRegistrationDateSalonAsync()
        {
            return await _client.PostAsync("minRegistrationDate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxRegistrationDateSalonAsync()
        {
            return await _client.PostAsync("maxRegistrationDate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSalonsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSalonsAsync(SalonsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }
    }
}
