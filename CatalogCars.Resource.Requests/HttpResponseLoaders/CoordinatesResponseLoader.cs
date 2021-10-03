using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class CoordinatesResponseLoader : BaseResponseLoader
    {
        private readonly CoordinatesClient _client;

        public CoordinatesResponseLoader()
        {
            _client = new CoordinatesClient();
        }

        public async Task<Stream> GetStreamFromGetCountCoordinatesResponseAsync(CoordinatesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountCoordinatesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesCoordinatesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesCoordinatesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetCoordinatesResponseAsync(CoordinatesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCoordinatesAsync(filters));
        }
    }
}
