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

        public async Task<Stream> GetStreamFromGetPriceSegmentsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentsAsync());
        }
    }
}
