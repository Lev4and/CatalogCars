using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class ColorTypesClient : BaseHttpClient
    {
        public ColorTypesClient() : base("colorTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountColorTypesAsync(ColorTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesColorTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetColorTypesAsync(ColorTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsColorTypeAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetColorTypeAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddColorTypeAsync(ColorType ColorType)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(ColorType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateColorTypeAsync(ColorType ColorType)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(ColorType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteColorTypeAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
