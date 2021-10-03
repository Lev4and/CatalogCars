using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PtsTypesResponseLoader : BaseResponseLoader
    {
        private readonly PtsTypesClient _client;

        public PtsTypesResponseLoader()
        {
            _client = new PtsTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPtsTypesResponseAsync(PtsTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPtsTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPtsTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPtsTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPtsTypesResponseAsync(PtsTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPtsTypesAsync(filters));
        }
    }
}
