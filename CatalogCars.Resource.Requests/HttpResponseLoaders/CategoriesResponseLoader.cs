using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class CategoriesResponseLoader : BaseResponseLoader
    {
        private readonly CategoriesClient _client;

        public CategoriesResponseLoader()
        {
            _client = new CategoriesClient();
        }

        public async Task<Stream> GetStreamFromGetCountCategoriesResponseAsync(CategoriesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountCategoriesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesCategoriesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesCategoriesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetCategoriesResponseAsync(CategoriesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCategoriesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsCategoryResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsCategoryAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetCategoryResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetCategoryAsync(id));
        }

        public async Task<Stream> GetStreamFromAddCategoryResponseAsync(Category category)
        {
            return await GetStreamFromResponseAsync(await _client.AddCategoryAsync(category));
        }

        public async Task<Stream> GetStreamFromUpdateCategoryResponseAsync(Category category)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateCategoryAsync(category));
        }

        public async Task<Stream> GetStreamFromDeleteCategoryResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteCategoryAsync(id));
        }
    }
}
