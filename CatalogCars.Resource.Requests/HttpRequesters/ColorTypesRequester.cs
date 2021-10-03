using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ColorTypesRequester
    {
        private readonly ColorTypesResponseLoader _responseLoader;

        public ColorTypesRequester()
        {
            _responseLoader = new ColorTypesResponseLoader();
        }

        public async Task<int> GetCountColorTypesAsync(ColorTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountColorTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesColorTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesColorTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<ColorType[]> GetColorTypesAsync(ColorTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetColorTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<ColorType[]>(await stream.ReadToEndAsync());
                }
            }

            return new ColorType[0];
        }
    }
}
