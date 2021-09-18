using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class ModelsClient : BaseHttpClient
    {
        public ModelsClient() : base("models/")
        {

        }

        public async Task<HttpResponseMessage> GetCountModelsAsync(ModelsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetCountModelsOfMarksAsync(ModelsFilters filters)
        {
            return await _client.PostAsync("byMarksIds/count", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesModelsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetModelsAsync(ModelsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }

        public async Task<HttpResponseMessage> GetModelsOfMarksAsync(ModelsFilters filters)
        {
            return await _client.PostAsync("byMarksIds", new StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8,
                "application/json"));
        }
    }
}
