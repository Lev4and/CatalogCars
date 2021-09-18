using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class GenerationsClient : BaseHttpClient
    {
        public GenerationsClient(): base("generations/")
        {

        }

        public async Task<HttpResponseMessage> GetCountGenerationsAsync(GenerationsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetGenerationsAsync(GenerationsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxYearFromGenerationAsync()
        {
            return await _client.PostAsync("maxYearFromGeneration", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinYearFromGenerationAsync()
        {
            return await _client.PostAsync("minYearFromGeneration", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesGenerationsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString), Encoding.UTF8,
                "application/json"));
        }
    }
}
