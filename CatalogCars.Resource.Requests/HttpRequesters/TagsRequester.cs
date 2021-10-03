using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
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
    }
}
