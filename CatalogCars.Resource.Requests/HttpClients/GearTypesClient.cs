using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class GearTypesClient : BaseHttpClient
    {
        public GearTypesClient() : base("gearTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountGearTypesAsync(GearTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesGearTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetGearTypesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetGearTypesAsync(GearTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsGearTypeAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetGearTypeAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddGearTypeAsync(GearType gearType)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(gearType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateGearTypeAsync(GearType gearType)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(gearType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteGearTypeAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
