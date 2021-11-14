using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class TransmissionsClient : BaseHttpClient
    {
        public TransmissionsClient() : base("transmissions/")
        {

        }

        public async Task<HttpResponseMessage> GetCountTransmissionsAsync(TransmissionsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesTransmissionsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetTransmissionsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetTransmissionsAsync(TransmissionsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsTransmissionAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetTransmissionAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddTransmissionAsync(Transmission transmission)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(transmission),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateTransmissionAsync(Transmission transmission)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(transmission),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteTransmissionAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
