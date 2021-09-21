using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class LocationsResponseLoader : BaseResponseLoader
    {
        private readonly LocationsClient _client;

        public LocationsResponseLoader()
        {
            _client = new LocationsClient();
        }

        public async Task<Stream> GetStreamFromGetCountLocationsResponseAsync(LocationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountLocationsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesLocationsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesLocationsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetLocationsResponseAsync(LocationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetLocationsAsync(filters));
        }
    }
}
