using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromGetTagsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetTagsAsync());
        }

        public async Task<Stream> GetStreamFromGetTagsResponseAsync(TagsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetTagsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsTagResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsTagAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetTagResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetTagAsync(id));
        }

        public async Task<Stream> GetStreamFromAddTagResponseAsync(Tag tag)
        {
            return await GetStreamFromResponseAsync(await _client.AddTagAsync(tag));
        }

        public async Task<Stream> GetStreamFromUpdateTagResponseAsync(Tag tag)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateTagAsync(tag));
        }

        public async Task<Stream> GetStreamFromDeleteTagResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteTagAsync(id));
        }
    }
}
