using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class StatesResponseLoader : BaseResponseLoader
    {
        private readonly StatesClient _client;

        public StatesResponseLoader()
        {
            _client = new StatesClient();
        }

        public async Task<Stream> GetStreamFromGetMinMileageResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinMileageAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxMileageResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxMileageAsync());
        }
    }
}
