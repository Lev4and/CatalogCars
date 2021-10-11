using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class AnnouncementAdditionalInformationResponseLoader : BaseResponseLoader
    {
        private readonly AnnouncementAdditionalInformationClient _client;

        public AnnouncementAdditionalInformationResponseLoader()
        {
            _client = new AnnouncementAdditionalInformationClient();
        }

        public async Task<Stream> GetStreamFromGetMinCreatedAtResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinCreatedAtAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxCreatedAtResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxCreatedAtAsync());
        }
    }
}
