using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
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

        public async Task<Stream> GetStreamFromGetBodyTypeGroupsResponseAsync(BodyTypeGroupsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetBodyTypeGroupsAsync(filters));
        }
    }
}
