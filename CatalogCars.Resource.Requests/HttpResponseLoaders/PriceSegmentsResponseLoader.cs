using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PriceSegmentsResponseLoader : BaseResponseLoader
    {
        private readonly PriceSegmentsClient _client;

        public PriceSegmentsResponseLoader()
        {
            _client = new PriceSegmentsClient();
        }

        public async Task<Stream> GetStreamFromGetCountPriceSegmentsResponseAsync(PriceSegmentsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPriceSegmentsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPriceSegmentsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPriceSegmentsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPriceSegmentsResponseAsync(PriceSegmentsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetPriceSegmentsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentsAsync());
        }
    }
}
