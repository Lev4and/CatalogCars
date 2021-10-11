using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class TechnicalParametersResponseLoader : BaseResponseLoader
    {
        private readonly TechnicalParametersClient _client;

        public TechnicalParametersResponseLoader()
        {
            _client = new TechnicalParametersClient();
        }

        public async Task<Stream> GetStreamFromGetMinPowerResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinPowerAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxPowerResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxPowerAsync());
        }

        public async Task<Stream> GetStreamFromGetMinPowerKvtResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinPowerKvtAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxPowerKvtResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxPowerKvtAsync());
        }

        public async Task<Stream> GetStreamFromGetMinDisplacementResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinDisplacementAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxDisplacementResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxDisplacementAsync());
        }

        public async Task<Stream> GetStreamFromGetMinClearanceMinResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinClearanceMinAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxClearanceMinResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxClearanceMinAsync());
        }

        public async Task<Stream> GetStreamFromGetMinFuelRateResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinFuelRateAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxFuelRateResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxFuelRateAsync());
        }

        public async Task<Stream> GetStreamFromGetMinAccelerationResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinAccelerationAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxAccelerationResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxAccelerationAsync());
        }
    }
}
