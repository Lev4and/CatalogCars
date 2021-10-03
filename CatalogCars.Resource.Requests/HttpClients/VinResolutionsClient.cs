using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class VinResolutionsClient : BaseHttpClient
    {
        public VinResolutionsClient() : base("vinResolutions/")
        {

        }

        public async Task<HttpResponseMessage> GetCountVinResolutionsAsync(VinResolutionsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesVinResolutionsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetVinResolutionsAsync(VinResolutionsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }
    }
}
