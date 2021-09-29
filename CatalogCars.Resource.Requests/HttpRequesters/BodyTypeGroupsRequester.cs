using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class BodyTypeGroupsRequester
    {
        private readonly BodyTypeGroupsResponseLoader _responseLoader;

        public BodyTypeGroupsRequester()
        {
            _responseLoader = new BodyTypeGroupsResponseLoader();
        }

        public async Task<int> GetCountBodyTypeGroupsAsync(BodyTypeGroupsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountBodyTypeGroupsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesBodyTypeGroupsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesBodyTypeGroupsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<BodyTypeGroup[]> GetBodyTypeGroupsAsync(BodyTypeGroupsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetBodyTypeGroupsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<BodyTypeGroup[]>(await stream.ReadToEndAsync());
                }
            }

            return new BodyTypeGroup[0];
        }
    }
}
