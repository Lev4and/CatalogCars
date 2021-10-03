using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class GearTypesResponseLoader : BaseResponseLoader
    {
        private readonly GearTypesClient _client;

        public GearTypesResponseLoader()
        {
            _client = new GearTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountGearTypesResponseAsync(GearTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountGearTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesGearTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesGearTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetGearTypesResponseAsync(GearTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetGearTypesAsync(filters));
        }
    }
}
