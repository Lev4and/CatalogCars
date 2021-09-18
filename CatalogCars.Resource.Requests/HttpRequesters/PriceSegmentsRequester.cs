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
