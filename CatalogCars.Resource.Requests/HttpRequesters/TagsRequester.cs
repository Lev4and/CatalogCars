using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class TagsRequester
    {
        private readonly TagsResponseLoader _responseLoader;

        public TagsRequester()
        {
            _responseLoader = new TagsResponseLoader();
        }

        public async Task<int> GetCountTagsAsync(TagsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountTagsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesTagsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesTagsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Tag[]> GetTagsAsync(TagsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetTagsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Tag[]>(await stream.ReadToEndAsync());
                }
            }

            return new Tag[0];
        }

        public async Task<bool> ContainsTagAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsTagResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Tag> GetTagAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetTagResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Tag>(await stream.ReadToEndAsync());
                }
            }

            return new Tag();
        }

        public async Task<SaveResult<object>> AddTagAsync(Tag tag)
        {
            var resultStream = await _responseLoader.GetStreamFromAddTagResponseAsync(tag);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateTagAsync(Tag tag)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateTagResponseAsync(tag);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteTagAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteTagResponseAsync(id);
        }
    }
}
