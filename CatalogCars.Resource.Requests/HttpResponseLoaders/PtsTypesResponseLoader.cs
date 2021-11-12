using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PtsTypesResponseLoader : BaseResponseLoader
    {
        private readonly PtsTypesClient _client;

        public PtsTypesResponseLoader()
        {
            _client = new PtsTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPtsTypesResponseAsync(PtsTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPtsTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPtsTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPtsTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPtsTypesResponseAsync(PtsTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPtsTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsPtsTypeResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsPtsTypeAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetPtsTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetPtsTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddPtsTypeResponseAsync(PtsType ptsType)
        {
            return await GetStreamFromResponseAsync(await _client.AddPtsTypeAsync(ptsType));
        }

        public async Task<Stream> GetStreamFromUpdatePtsTypeResponseAsync(PtsType ptsType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdatePtsTypeAsync(ptsType));
        }

        public async Task<Stream> GetStreamFromDeletePtsTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeletePtsTypeAsync(id));
        }
    }
}
