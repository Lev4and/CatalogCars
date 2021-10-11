using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class AnnouncementAdditionalInformationRequester
    {
        private readonly AnnouncementAdditionalInformationResponseLoader _responseLoader;

        public AnnouncementAdditionalInformationRequester()
        {
            _responseLoader = new AnnouncementAdditionalInformationResponseLoader();
        }

        public async Task<DateTime> GetMinCreatedAtAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinCreatedAtResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<DateTime>(await stream.ReadToEndAsync());
                }
            }

            return DateTime.Now;
        }

        public async Task<DateTime> GetMaxCreatedAtAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxCreatedAtResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<DateTime>(await stream.ReadToEndAsync());
                }
            }

            return DateTime.Now;
        }
    }
}
