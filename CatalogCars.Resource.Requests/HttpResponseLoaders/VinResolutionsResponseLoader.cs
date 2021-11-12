using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class VinResolutionsResponseLoader : BaseResponseLoader
    {
        private readonly VinResolutionsClient _client;

        public VinResolutionsResponseLoader()
        {
            _client = new VinResolutionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountVinResolutionsResponseAsync(VinResolutionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountVinResolutionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesVinResolutionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesVinResolutionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetVinResolutionsResponseAsync(VinResolutionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetVinResolutionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsVinResolutionResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsVinResolutionAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetVinResolutionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetVinResolutionAsync(id));
        }

        public async Task<Stream> GetStreamFromAddVinResolutionResponseAsync(VinResolution vinResolution)
        {
            return await GetStreamFromResponseAsync(await _client.AddVinResolutionAsync(vinResolution));
        }

        public async Task<Stream> GetStreamFromUpdateVinResolutionResponseAsync(VinResolution vinResolution)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateVinResolutionAsync(vinResolution));
        }

        public async Task<Stream> GetStreamFromDeleteVinResolutionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteVinResolutionAsync(id));
        }
    }
}
