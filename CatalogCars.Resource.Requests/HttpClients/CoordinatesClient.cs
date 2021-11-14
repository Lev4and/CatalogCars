using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class CoordinatesClient : BaseHttpClient
    {
        public CoordinatesClient() : base("coordinates/")
        {

        }

        public async Task<HttpResponseMessage> GetCountCoordinatesAsync(CoordinatesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesCoordinatesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetCoordinatesAsync(CoordinatesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsCoordinateAsync(Guid locationId, double latitude, double longitude)
        {
            return await _client.GetAsync($"contains?locationId={locationId}&latitude={latitude}&longitude={longitude}");
        }

        public async Task<HttpResponseMessage> GetCoordinateAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddCoordinateAsync(Coordinate coordinate)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(coordinate),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateCoordinateAsync(Coordinate coordinate)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(coordinate),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteCoordinateAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
