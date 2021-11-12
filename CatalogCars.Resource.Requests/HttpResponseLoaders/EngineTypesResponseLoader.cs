using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromContainsEngineTypeResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsEngineTypeAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetEngineTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetEngineTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddEngineTypeResponseAsync(EngineType engineType)
        {
            return await GetStreamFromResponseAsync(await _client.AddEngineTypeAsync(engineType));
        }

        public async Task<Stream> GetStreamFromUpdateEngineTypeResponseAsync(EngineType engineType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateEngineTypeAsync(engineType));
        }

        public async Task<Stream> GetStreamFromDeleteEngineTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteEngineTypeAsync(id));
        }
    }
}
