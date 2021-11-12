using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
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

        public async Task<HttpResponseMessage> ContainsVinResolutionAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetVinResolutionAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddVinResolutionAsync(VinResolution vinResolution)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(vinResolution),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateVinResolutionAsync(VinResolution vinResolution)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(vinResolution),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteVinResolutionAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
