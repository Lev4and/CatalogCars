using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class LocationsClient : BaseHttpClient
    {
        public LocationsClient() : base("locations/")
        {

        }

        public async Task<HttpResponseMessage> GetCountLocationsAsync(LocationsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesLocationsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetLocationsAsync(LocationsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }
    }
}
