using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class BodyTypesRequester
    {
        private readonly BodyTypesResponseLoader _responseLoader;

        public BodyTypesRequester()
        {
            _responseLoader = new BodyTypesResponseLoader();
        }

        public async Task<int> GetCountBodyTypesAsync(BodyTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountBodyTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetCountBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountBodyTypesOfBodyTypeGroupsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesBodyTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesBodyTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<BodyType[]> GetBodyTypesAsync(BodyTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetBodyTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<BodyType[]>(await stream.ReadToEndAsync());
                }
            }

            return new BodyType[0];
        }

        public async Task<BodyType[]> GetBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetBodyTypesOfBodyTypeGroupsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<BodyType[]>(await stream.ReadToEndAsync());
                }
            }

            return new BodyType[0];
        }
    }
}
