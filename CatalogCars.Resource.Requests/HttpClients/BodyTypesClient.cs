using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class BodyTypesClient : BaseHttpClient
    {
        public BodyTypesClient() : base("bodyTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountBodyTypesAsync(BodyTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetCountBodyTypesOfBodyTypeGroups(BodyTypesFilters filters)
        {
            return await _client.PostAsync("byBodyTypeGroupsIds/count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesBodyTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetBodyTypesAsync(BodyTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters filters)
        {
            return await _client.PostAsync("byBodyTypeGroupsIds", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }
    }
}
