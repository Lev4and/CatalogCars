using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class GenerationsRequester
    {
        private readonly GenerationsResponseLoader _responseLoader;

        public GenerationsRequester()
        {
            _responseLoader = new GenerationsResponseLoader();
        }

        public async Task<int> GetCountGenerationsAsync(GenerationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountGenerationsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetCountGenerationsByModelsIdsAsync(GenerationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountGenerationsByModelsIdsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<Generation[]> GetGenerationsAsync(GenerationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetGenerationsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Generation[]>(await stream.ReadToEndAsync());
                }
            }

            return new Generation[0];
        }

        public async Task<Generation[]> GetGenerationsByModelsIdsAsync(GenerationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetGenerationsByModelsIdsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Generation[]>(await stream.ReadToEndAsync());
                }
            }

            return new Generation[0];
        }

        public async Task<int?> GetMaxYearFromGenerationAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxYearFromGenerationResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<int?> GetMinYearFromGenerationAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinYearFromGenerationResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<string[]> GetNamesGenerationsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesGenerationsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }
    }
}
