using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class ColorsClient : BaseHttpClient
    {
        public ColorsClient() : base("colors/")
        {

        }

        public async Task<HttpResponseMessage> GetCountColorsAsync(ColorsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesColorsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetColorsAsync(ColorsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsColorAsync(string value)
        {
            return await _client.GetAsync($"contains?value={value}");
        }

        public async Task<HttpResponseMessage> GetColorAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddColorAsync(Color color)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(color),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateColorAsync(Color color)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(color),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteColorAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
