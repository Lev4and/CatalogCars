using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SellersClient : BaseHttpClient
    {
        public SellersClient() : base("sellers/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSellersAsync(SellersFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSellersAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSellersAsync(SellersFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsSellerAsync(Guid locationId)
        {
            return await _client.GetAsync($"contains?locationId={locationId}");
        }

        public async Task<HttpResponseMessage> GetSellerAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddSellerAsync(Seller seller)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(seller),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateSellerAsync(Seller seller)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(seller),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteSellerAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
