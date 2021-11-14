using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class TagsClient : BaseHttpClient
    {
        public TagsClient() : base("tags/")
        {

        }

        public async Task<HttpResponseMessage> GetCountTagsAsync(TagsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesTagsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetTagsAsync(TagsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsTagAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetTagAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddTagAsync(Tag tag)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(tag),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateTagAsync(Tag tag)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(tag),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteTagAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
