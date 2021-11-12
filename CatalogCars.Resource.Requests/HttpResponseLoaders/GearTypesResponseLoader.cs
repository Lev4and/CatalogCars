using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class GearTypesResponseLoader : BaseResponseLoader
    {
        private readonly GearTypesClient _client;

        public GearTypesResponseLoader()
        {
            _client = new GearTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountGearTypesResponseAsync(GearTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountGearTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesGearTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesGearTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetGearTypesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetGearTypesAsync());
        }

        public async Task<Stream> GetStreamFromGetGearTypesResponseAsync(GearTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetGearTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsGearTypeResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsGearTypeAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetGearTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetGearTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddGearTypeResponseAsync(GearType gearType)
        {
            return await GetStreamFromResponseAsync(await _client.AddGearTypeAsync(gearType));
        }

        public async Task<Stream> GetStreamFromUpdateGearTypeResponseAsync(GearType gearType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateGearTypeAsync(gearType));
        }

        public async Task<Stream> GetStreamFromDeleteGearTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteGearTypeAsync(id));
        }
    }
}
