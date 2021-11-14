using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SellerTypesClient : BaseHttpClient
    {
        public SellerTypesClient() : base("sellerTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSellerTypesAsync(SellerTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSellerTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSellerTypesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetSellerTypesAsync(SellerTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsSellerTypeAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetSellerTypeAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddSellerTypeAsync(SellerType sellerType)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(sellerType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateSellerTypeAsync(SellerType sellerType)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(sellerType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteSellerTypeAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
