using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class OptionsRequester
    {
        private readonly OptionsResponseLoader _responseLoader;

        public OptionsRequester()
        {
            _responseLoader = new OptionsResponseLoader();
        }

        public async Task<int> GetCountOptionsAsync(OptionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountOptionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesOptionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesOptionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Option[]> GetOptionsAsync(OptionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetOptionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Option[]>(await stream.ReadToEndAsync());
                }
            }

            return new Option[0];
        }
    }
}
