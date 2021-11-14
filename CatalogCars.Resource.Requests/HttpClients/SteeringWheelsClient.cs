using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SteeringWheelsClient : BaseHttpClient
    {
        public SteeringWheelsClient() : base("steeringWheels/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSteeringWheelsAsync(SteeringWheelsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSteeringWheelsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSteeringWheelsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetSteeringWheelsAsync(SteeringWheelsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsSteeringWheelAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetSteeringWheelAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddSteeringWheelAsync(SteeringWheel steeringWheel)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(steeringWheel),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateSteeringWheelAsync(SteeringWheel steeringWheel)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(steeringWheel),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteSteeringWheelAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
