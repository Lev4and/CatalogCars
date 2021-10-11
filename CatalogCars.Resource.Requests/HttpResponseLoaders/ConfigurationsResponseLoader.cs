using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ConfigurationsResponseLoader : BaseResponseLoader
    {
        private readonly ConfigurationsClient _client;

        public ConfigurationsResponseLoader()
        {
            _client = new ConfigurationsClient();
        }

        public async Task<Stream> GetStreamFromGetMaxDoorsCountResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxDoorsCountAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxTrunkVolumeMaxResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxTrunkVolumeMaxAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxTrunkVolumeMinResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxTrunkVolumeMinAsync());
        }

        public async Task<Stream> GetStreamFromGetMinDoorsCountResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinDoorsCountAsync());
        }

        public async Task<Stream> GetStreamFromGetMinTrunkVolumeMaxResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinTrunkVolumeMaxAsync());
        }

        public async Task<Stream> GetStreamFromGetMinTrunkVolumeMinResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinTrunkVolumeMinAsync());
        }
    }
}
