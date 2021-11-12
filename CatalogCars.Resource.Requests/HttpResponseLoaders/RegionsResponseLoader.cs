using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class RegionsResponseLoader : BaseResponseLoader
    {
        private readonly RegionsClient _client;

        public RegionsResponseLoader()
        {
            _client = new RegionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountRegionsResponseAsync(RegionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountRegionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesRegionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesRegionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetRegionsResponseAsync(RegionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetRegionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsRegionResponseAsync(string stringId)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsRegionAsync(stringId));
        }

        public async Task<Stream> GetStreamFromGetRegionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetRegionAsync(id));
        }

        public async Task<Stream> GetStreamFromAddRegionResponseAsync(RegionInformation region)
        {
            return await GetStreamFromResponseAsync(await _client.AddRegionAsync(region));
        }

        public async Task<Stream> GetStreamFromUpdateRegionResponseAsync(RegionInformation region)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateRegionAsync(region));
        }

        public async Task<Stream> GetStreamFromDeleteRegionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteRegionAsync(id));
        }
    }
}
