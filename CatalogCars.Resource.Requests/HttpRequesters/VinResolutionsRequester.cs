using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class VinResolutionsRequester
    {
        private readonly VinResolutionsResponseLoader _responseLoader;

        public VinResolutionsRequester()
        {
            _responseLoader = new VinResolutionsResponseLoader();
        }

        public async Task<int> GetCountVinResolutionsAsync(VinResolutionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountVinResolutionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesVinResolutionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesVinResolutionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<VinResolution[]> GetVinResolutionsAsync(VinResolutionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetVinResolutionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<VinResolution[]>(await stream.ReadToEndAsync());
                }
            }

            return new VinResolution[0];
        }
    }
}
