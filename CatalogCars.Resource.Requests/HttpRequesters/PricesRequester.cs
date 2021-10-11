using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PricesRequester
    {
        private readonly PricesResponseLoader _responseLoader;

        public PricesRequester()
        {
            _responseLoader = new PricesResponseLoader();
        }

        public async Task<double> GetMinPriceAsync(Guid currencyId)
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinPriceResponseAsync(currencyId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<double> GetMaxPriceAsync(Guid currencyId)
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxPriceResponseAsync(currencyId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }
    }
}
