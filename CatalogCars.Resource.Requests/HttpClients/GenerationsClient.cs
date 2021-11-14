using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
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

        public async Task<HttpResponseMessage> GetCountGenerationsByModelsIdsAsync(GenerationsFilters filters)
        {
            return await _client.PostAsync("byModelsIds/count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetGenerationsAsync(GenerationsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetGenerationsByModelsIdsAsync(GenerationsFilters filters)
        {
            return await _client.PostAsync("byModelsIds", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
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

        public async Task<HttpResponseMessage> ContainsGenerationAsync(Guid modelId, int? yearFrom = null, string name = null)
        {
            return await _client.GetAsync($"contains?modelId={modelId}{(yearFrom != null ? $"&yearFrom={yearFrom}" : "")}" +
                $"{(name != null ? $"&name={name}" : "")}");
        }

        public async Task<HttpResponseMessage> GetGenerationAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddGenerationAsync(Generation generation)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(generation),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateGenerationAsync(Generation generation)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(generation),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteGenerationAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
