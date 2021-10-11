using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ConfigurationsRequester
    {
        private readonly ConfigurationsResponseLoader _responseLoader;

        public ConfigurationsRequester()
        {
            _responseLoader = new ConfigurationsResponseLoader();
        }

        public async Task<int> GetMaxDoorsCountAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxDoorsCountResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<double?> GetMaxTrunkVolumeMaxAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxTrunkVolumeMaxResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<double?> GetMaxTrunkVolumeMinAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxTrunkVolumeMinResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<int> GetMinDoorsCountAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinDoorsCountResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<double?> GetMinTrunkVolumeMaxAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinTrunkVolumeMaxResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<double?> GetMinTrunkVolumeMinAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinTrunkVolumeMinResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }
    }
}
