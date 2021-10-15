using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PtsResponseLoader : BaseResponseLoader
    {
        private readonly PtsClient _client;

        public PtsResponseLoader()
        {
            _client = new PtsClient();
        }

        public async Task<Stream> GetStreamFromGetMinOwnersNumberResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinOwnersNumberAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxOwnersNumberResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxOwnersNumberAsync());
        }
    }
}
