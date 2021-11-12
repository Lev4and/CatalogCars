using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class BodyTypeGroupsResponseLoader : BaseResponseLoader
    {
        private readonly BodyTypeGroupsClient _client;

        public BodyTypeGroupsResponseLoader()
        {
            _client = new BodyTypeGroupsClient();
        }

        public async Task<Stream> GetStreamFromGetCountBodyTypeGroupsResponseAsync(BodyTypeGroupsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountBodyTypeGroupsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesBodyTypeGroupsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesBodyTypeGroupsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetBodyTypeGroupsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypeGroupsAsync());
        }

        public async Task<Stream> GetStreamFromGetBodyTypeGroupsResponseAsync(BodyTypeGroupsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypeGroupsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsBodyTypeGroupResponseAsync(string autoClass, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsBodyTypeGroupAsync(autoClass, ruName));
        }

        public async Task<Stream> GetStreamFromGetBodyTypeGroupResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypeGroupAsync(id));
        }

        public async Task<Stream> GetStreamFromAddBodyTypeGroupResponseAsync(BodyTypeGroup bodyTypeGroup)
        {
            return await GetStreamFromResponseAsync(await _client.AddBodyTypeGroupAsync(bodyTypeGroup));
        }

        public async Task<Stream> GetStreamFromUpdateBodyTypeGroupResponseAsync(BodyTypeGroup bodyTypeGroup)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateBodyTypeGroupAsync(bodyTypeGroup));
        }

        public async Task<Stream> GetStreamFromDeleteBodyTypeGroupResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteBodyTypeGroupAsync(id));
        }
    }
}
