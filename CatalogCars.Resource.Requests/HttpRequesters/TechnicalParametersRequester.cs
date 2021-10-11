using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class TechnicalParametersRequester
    {
        private readonly TechnicalParametersResponseLoader _responseLoader;

        public TechnicalParametersRequester()
        {
            _responseLoader = new TechnicalParametersResponseLoader();
        }

        public async Task<int> GetMinPowerAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinPowerResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMaxPowerAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxPowerResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMinPowerKvtAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinPowerKvtResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMaxPowerKvtAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxPowerKvtResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMinDisplacementAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinDisplacementResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMaxDisplacementAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxDisplacementResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMinClearanceMinAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinClearanceMinResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMaxClearanceMinAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxClearanceMinResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<double?> GetMinFuelRateAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinFuelRateResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<double?> GetMaxFuelRateAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxFuelRateResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<double> GetMinAccelerationAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinAccelerationResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<double>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<double> GetMaxAccelerationAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxAccelerationResponseAsync();

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
