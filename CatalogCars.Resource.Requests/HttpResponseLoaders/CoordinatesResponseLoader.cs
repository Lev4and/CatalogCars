using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromContainsCoordinateResponseAsync(Guid locationId, double latitude, double longitude)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsCoordinateAsync(locationId, latitude, longitude));
        }

        public async Task<Stream> GetStreamFromGetCoordinateResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetCoordinateAsync(id));
        }

        public async Task<Stream> GetStreamFromAddCoordinateResponseAsync(Coordinate coordinate)
        {
            return await GetStreamFromResponseAsync(await _client.AddCoordinateAsync(coordinate));
        }

        public async Task<Stream> GetStreamFromUpdateCoordinateResponseAsync(Coordinate coordinate)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateCoordinateAsync(coordinate));
        }

        public async Task<Stream> GetStreamFromDeleteCoordinateResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteCoordinateAsync(id));
        }
    }
}
