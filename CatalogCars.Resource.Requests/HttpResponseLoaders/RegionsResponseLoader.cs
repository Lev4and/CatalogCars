using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class RegionsResponseLoader : BaseResponseLoader
    {
        private readonly RegionsClient _client;

        public RegionsResponseLoader()
        {
            _client = new RegionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountRegionsResponseAsync(RegionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountRegionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesRegionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesRegionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetRegionsResponseAsync(RegionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetRegionsAsync(filters));
        }
    }
}
