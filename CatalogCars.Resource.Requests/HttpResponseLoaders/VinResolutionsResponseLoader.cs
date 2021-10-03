using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class VinResolutionsResponseLoader : BaseResponseLoader
    {
        private readonly VinResolutionsClient _client;

        public VinResolutionsResponseLoader()
        {
            _client = new VinResolutionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountVinResolutionsResponseAsync(VinResolutionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountVinResolutionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesVinResolutionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesVinResolutionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetVinResolutionsResponseAsync(VinResolutionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetVinResolutionsAsync(filters));
        }
    }
}
