using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class CategoriesClient : BaseHttpClient
    {
        public CategoriesClient() : base("categories/")
        {

        }

        public async Task<HttpResponseMessage> GetCountCategoriesAsync(CategoriesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesCategoriesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetCategoriesAsync(CategoriesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsCategoryAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetCategoryAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddCategoryAsync(Category category)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(category),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(Category category)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(category),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
