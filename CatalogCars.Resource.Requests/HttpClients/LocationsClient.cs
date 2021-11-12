using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
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

        public async Task<HttpResponseMessage> ContainsLocationAsync(double latitude, double longitude)
        {
            return await _client.GetAsync($"contains?latitude={latitude}&longitude={longitude}");
        }

        public async Task<HttpResponseMessage> GetLocationAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddLocationAsync(Location location)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(location),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateLocationAsync(Location location)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(location),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteLocationAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
