using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PricesResponseLoader : BaseResponseLoader
    {
        private readonly PricesClient _client;

        public PricesResponseLoader()
        {
            _client = new PricesClient();
        }

        public async Task<Stream> GetStreamFromGetMinPriceResponseAsync(Guid currencyId)
        {
            return await GetStreamFromResponseAsync(await _client.GetMinPriceAsync(currencyId));
        }

        public async Task<Stream> GetStreamFromGetMaxPriceResponseAsync(Guid currencyId)
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxPriceAsync(currencyId));
        }
    }
}
