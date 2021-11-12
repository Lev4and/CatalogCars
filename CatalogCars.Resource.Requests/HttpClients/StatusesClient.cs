using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class StatusesClient : BaseHttpClient
    {
        public StatusesClient() : base("statuses/")
        {

        }

        public async Task<HttpResponseMessage> GetCountStatusesAsync(StatusesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesStatusesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetStatusesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetStatusesAsync(StatusesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsStatusAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetStatusAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddStatusAsync(Status status)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(status),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateStatusAsync(Status status)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(status),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteStatusAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
