using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class StatesRequester
    {
        private readonly StatesResponseLoader _responseLoader;

        public StatesRequester()
        {
            _responseLoader = new StatesResponseLoader();
        }

        public async Task<int> GetMinMileageAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinMileageResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetMaxMileageAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxMileageResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }
    }
}
