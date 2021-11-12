using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SalonsClient : BaseHttpClient
    {
        public SalonsClient() : base("salons/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSalonsAsync(SalonsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinRegistrationDateSalonAsync()
        {
            return await _client.PostAsync("minRegistrationDate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxRegistrationDateSalonAsync()
        {
            return await _client.PostAsync("maxRegistrationDate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSalonsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSalonsAsync(SalonsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsSalonAsync(Guid locationId, string name)
        {
            return await _client.GetAsync($"contains?locationId={locationId}&name={name}");
        }

        public async Task<HttpResponseMessage> GetSalonAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddSalonAsync(Salon salon)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(salon),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateSalonAsync(Salon salon)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(salon),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteSalonAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
