using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class AvailabilitiesResponseLoader : BaseResponseLoader
    {
        private readonly AvailabilitiesClient _client;

        public AvailabilitiesResponseLoader()
        {
            _client = new AvailabilitiesClient();
        }

        public async Task<Stream> GetStreamFromGetCountAvailabilitiesResponseAsync(AvailabilitiesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountAvailabilitiesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesAvailabilitiesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesAvailabilitiesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetAvailabilitiesResponseAsync(AvailabilitiesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetAvailabilitiesAsync(filters));
        }
    }
}
