using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class EngineTypesResponseLoader : BaseResponseLoader
    {
        private readonly EngineTypesClient _client;

        public EngineTypesResponseLoader()
        {
            _client = new EngineTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountEngineTypesResponseAsync(EngineTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountEngineTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesEngineTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesEngineTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetEngineTypesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetEngineTypesAsync());
        }

        public async Task<Stream> GetStreamFromGetEngineTypesResponseAsync(EngineTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetEngineTypesAsync(filters));
        }
    }
}
