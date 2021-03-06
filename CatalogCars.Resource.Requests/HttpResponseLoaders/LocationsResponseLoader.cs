using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromContainsLocationResponseAsync(double latitude, double longitude)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsLocationAsync(latitude, longitude));
        }

        public async Task<Stream> GetStreamFromGetLocationResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetLocationAsync(id));
        }

        public async Task<Stream> GetStreamFromAddLocationResponseAsync(Location location)
        {
            return await GetStreamFromResponseAsync(await _client.AddLocationAsync(location));
        }

        public async Task<Stream> GetStreamFromUpdateLocationResponseAsync(Location location)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateLocationAsync(location));
        }

        public async Task<Stream> GetStreamFromDeleteLocationResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteLocationAsync(id));
        }
    }
}
