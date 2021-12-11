using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class OptionsClient : BaseHttpClient
    {
        public OptionsClient() : base("options/")
        {

        }

        public async Task<HttpResponseMessage> GetCountOptionsAsync(OptionsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesOptionsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetOptionsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetOptionsAsync(OptionsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsOptionAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetOptionAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddOptionAsync(Option option)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(option),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateOptionAsync(Option option)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(option),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteOptionAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
