using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;
using Entities = CatalogCars.Model.Database.Entities;

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

        public async Task<Stream> GetStreamFromGetModelsOfMarksResponseAsync(Guid[] marksIds)
        {
            return await GetStreamFromResponseAsync(await _client.GetModelsOfMarksAsync(marksIds));
        }

        public async Task<Stream> GetStreamFromGetModelsOfMarksResponseAsync(ModelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetModelsOfMarksAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetPopularityModelsOfMarkResponseAsync(Guid markId)
        {
            return await GetStreamFromResponseAsync(await _client.GetPopularityModelsOfMark(markId));
        }

        public async Task<Stream> GetStreamFromContainsModelResponseAsync(Guid markId, string name)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsModelAsync(markId, name));
        }

        public async Task<Stream> GetStreamFromGetModelResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetModelAsync(id));
        }

        public async Task<Stream> GetStreamFromAddModelResponseAsync(Entities.Model model)
        {
            return await GetStreamFromResponseAsync(await _client.AddModelAsync(model));
        }

        public async Task<Stream> GetStreamFromUpdateModelResponseAsync(Entities.Model model)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateModelAsync(model));
        }

        public async Task<Stream> GetStreamFromDeleteModelResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteModelAsync(id));
        }
    }
}
