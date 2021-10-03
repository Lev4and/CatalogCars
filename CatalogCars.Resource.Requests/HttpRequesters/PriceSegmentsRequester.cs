using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PriceSegmentsRequester
    {
        private readonly PriceSegmentsResponseLoader _responseLoader;

        public PriceSegmentsRequester()
        {
            _responseLoader = new PriceSegmentsResponseLoader();
        }

        public async Task<int> GetCountPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountPriceSegmentsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesPriceSegmentsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesPriceSegmentsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<PriceSegment[]> GetPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPriceSegmentsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PriceSegment[]>(await stream.ReadToEndAsync());
                }
            }

            return new PriceSegment[0];
        }

        public async Task<PriceSegment[]> GetPriceSegmentsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetPriceSegmentsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PriceSegment[]>(await stream.ReadToEndAsync());
                }
            }

            return new PriceSegment[0];
        }
    }
}
