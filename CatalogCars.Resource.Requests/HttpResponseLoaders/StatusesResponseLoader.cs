using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class StatusesResponseLoader : BaseResponseLoader
    {
        private readonly StatusesClient _client;

        public StatusesResponseLoader()
        {
            _client = new StatusesClient();
        }

        public async Task<Stream> GetStreamFromGetCountStatusesResponseAsync(StatusesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountStatusesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesStatusesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesStatusesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetStatusesResponseAsync(StatusesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetStatusesAsync(filters));
        }
    }
}
