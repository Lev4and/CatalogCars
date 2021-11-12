using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class BodyTypesResponseLoader : BaseResponseLoader
    {
        private readonly BodyTypesClient _client;

        public BodyTypesResponseLoader()
        {
            _client = new BodyTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountBodyTypesResponseAsync(BodyTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountBodyTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetCountBodyTypesOfBodyTypeGroupsResponseAsync(BodyTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountBodyTypesOfBodyTypeGroups(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesBodyTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesBodyTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetBodyTypesResponseAsync(BodyTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetBodyTypesOfBodyTypeGroupsResponseAsync(BodyTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypesOfBodyTypeGroupsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsBodyTypeResponseAsync(Guid bodyTypeGroupId, string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsBodyTypeAsync(bodyTypeGroupId, name, ruName));
        }

        public async Task<Stream> GetStreamFromGetBodyTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddBodyTypeResponseAsync(BodyType bodyType)
        {
            return await GetStreamFromResponseAsync(await _client.AddBodyTypeAsync(bodyType));
        }

        public async Task<Stream> GetStreamFromUpdateBodyTypeResponseAsync(BodyType bodyType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateBodyTypeAsync(bodyType));
        }

        public async Task<Stream> GetStreamFromDeleteBodyTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteBodyTypeAsync(id));
        }
    }
}
