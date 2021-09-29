using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
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
    }
}
