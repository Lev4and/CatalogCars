using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class CurrenciesClient : BaseHttpClient
    {
        public CurrenciesClient() : base("currencies/")
        {

        }

        public async Task<HttpResponseMessage> GetCountCurrenciesAsync(CurrenciesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesCurrenciesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetCurrenciesAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetCurrenciesAsync(CurrenciesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsCurrencyAsync(string name)
        {
            return await _client.GetAsync($"contains?name={name}");
        }

        public async Task<HttpResponseMessage> GetCurrencyAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddCurrencyAsync(Currency currency)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(currency),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateCurrencyAsync(Currency currency)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(currency),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteCurrencyAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
