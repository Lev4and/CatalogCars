using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class BodyTypeGroupsClient : BaseHttpClient
    {
        public BodyTypeGroupsClient() : base("bodyTypeGroups/")
        {

        }

        public async Task<HttpResponseMessage> GetCountBodyTypeGroupsAsync(BodyTypeGroupsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesBodyTypeGroupsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetBodyTypeGroupsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetBodyTypeGroupsAsync(BodyTypeGroupsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsBodyTypeGroupAsync(string autoClass, string ruName)
        {
            return await _client.GetAsync($"contains?autoClass={autoClass}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetBodyTypeGroupAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddBodyTypeGroupAsync(BodyTypeGroup bodyTypeGroup)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(bodyTypeGroup),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateBodyTypeGroupAsync(BodyTypeGroup bodyTypeGroup)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(bodyTypeGroup),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteBodyTypeGroupAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
