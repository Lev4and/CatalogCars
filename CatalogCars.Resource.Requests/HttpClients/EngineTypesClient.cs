using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class EngineTypesClient : BaseHttpClient
    {
        public EngineTypesClient() : base("engineTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountEngineTypesAsync(EngineTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesEngineTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetEngineTypesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetEngineTypesAsync(EngineTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsEngineTypeAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetEngineTypeAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddEngineTypeAsync(EngineType engineType)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(engineType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateEngineTypeAsync(EngineType engineType)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(engineType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteEngineTypeAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
