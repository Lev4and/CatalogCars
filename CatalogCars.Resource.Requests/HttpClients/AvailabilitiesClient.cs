using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class AvailabilitiesClient : BaseHttpClient
    {
        public AvailabilitiesClient() : base("availabilities/")
        {

        }

        public async Task<HttpResponseMessage> GetCountAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesAvailabilitiesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetAvailabilitiesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsAvailabilityAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetAvailabilityAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddAvailabilityAsync(Availability availability)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(availability),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateAvailabilityAsync(Availability availability)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(availability),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteAvailabilityAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
