using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ModelsResponseLoader : BaseResponseLoader
    {
        private readonly ModelsClient _client;

        public ModelsResponseLoader()
        {
            _client = new ModelsClient();
        }

        public async Task<Stream> GetStreamFromGetCountModelsResponseAsync(ModelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountModelsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetCountModelsOfMarksResponseAsync(ModelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountModelsOfMarksAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesModelsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesModelsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetModelsResponseAsync(ModelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetModelsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetModelsOfMarksResponseAsync(ModelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetModelsOfMarksAsync(filters));
        }
    }
}
