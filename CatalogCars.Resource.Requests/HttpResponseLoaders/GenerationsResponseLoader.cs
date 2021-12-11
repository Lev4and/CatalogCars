using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class GenerationsResponseLoader : BaseResponseLoader
    {
        private readonly GenerationsClient _client;

        public GenerationsResponseLoader()
        {
            _client = new GenerationsClient();
        }

        public async Task<Stream> GetStreamFromGetCountGenerationsResponseAsync(GenerationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountGenerationsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetCountGenerationsByModelsIdsResponseAsync(GenerationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountGenerationsByModelsIdsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetGenerationsResponseAsync(GenerationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetGenerationsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetGenerationsOfModelsResponseAsync(List<Guid> modelsIds)
        {
            return await GetStreamFromResponseAsync(await _client.GetGenerationsOfModelsAsync(modelsIds));
        }

        public async Task<Stream> GetStreamFromGetGenerationsByModelsIdsResponseAsync(GenerationsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetGenerationsByModelsIdsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetMaxYearFromGenerationResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxYearFromGenerationAsync());
        }

        public async Task<Stream> GetStreamFromGetMinYearFromGenerationResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinYearFromGenerationAsync());
        }

        public async Task<Stream> GetStreamFromGetNamesGenerationsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesGenerationsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromContainsGenerationResponseAsync(Guid modelId, int? yearFrom = null, string name = null)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsGenerationAsync(modelId, yearFrom, name));
        }

        public async Task<Stream> GetStreamFromGetGenerationResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetGenerationAsync(id));
        }

        public async Task<Stream> GetStreamFromAddGenerationResponseAsync(Generation generation)
        {
            return await GetStreamFromResponseAsync(await _client.AddGenerationAsync(generation));
        }

        public async Task<Stream> GetStreamFromUpdateGenerationResponseAsync(Generation generation)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateGenerationAsync(generation));
        }

        public async Task<Stream> GetStreamFromDeleteGenerationResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteGenerationAsync(id));
        }
    }
}
