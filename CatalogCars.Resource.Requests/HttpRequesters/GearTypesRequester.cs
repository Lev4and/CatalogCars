using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class GearTypesRequester
    {
        private readonly GearTypesResponseLoader _responseLoader;

        public GearTypesRequester()
        {
            _responseLoader = new GearTypesResponseLoader();
        }

        public async Task<int> GetCountGearTypesAsync(GearTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountGearTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesGearTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesGearTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<GearType[]> GetGearTypesAsync(GearTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetGearTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<GearType[]>(await stream.ReadToEndAsync());
                }
            }

            return new GearType[0];
        }
    }
}
