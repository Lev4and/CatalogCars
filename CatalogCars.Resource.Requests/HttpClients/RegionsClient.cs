using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class RegionsClient : BaseHttpClient
    {
        public RegionsClient() : base("regions/")
        {

        }

        public async Task<HttpResponseMessage> GetCountRegionsAsync(RegionsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesRegionsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetRegionsAsync(RegionsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsRegionAsync(string stringId)
        {
            return await _client.GetAsync($"contains?stringId={stringId}");
        }

        public async Task<HttpResponseMessage> GetRegionAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddRegionAsync(RegionInformation region)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(region),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateRegionAsync(RegionInformation region)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(region),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteRegionAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
