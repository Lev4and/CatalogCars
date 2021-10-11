using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
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
    }
}
