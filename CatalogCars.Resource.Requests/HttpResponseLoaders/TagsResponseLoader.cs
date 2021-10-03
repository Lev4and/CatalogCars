using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class TagsResponseLoader : BaseResponseLoader
    {
        private readonly TagsClient _client;

        public TagsResponseLoader()
        {
            _client = new TagsClient();
        }

        public async Task<Stream> GetStreamFromGetCountTagsResponseAsync(TagsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountTagsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesTagsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesTagsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetTagsResponseAsync(TagsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetTagsAsync(filters));
        }
    }
}
