using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PtsRequester
    {
        private readonly PtsResponseLoader _responseLoader;

        public PtsRequester()
        {
            _responseLoader = new PtsResponseLoader();
        }

        public async Task<int?> GetMinYearAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinYearResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<int?> GetMaxYearAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxYearResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<int?> GetMinOwnersNumberAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinOwnersNumberResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }

        public async Task<int?> GetMaxOwnersNumberAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxOwnersNumberResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int?>(await stream.ReadToEndAsync());
                }
            }

            return null;
        }
    }
}
