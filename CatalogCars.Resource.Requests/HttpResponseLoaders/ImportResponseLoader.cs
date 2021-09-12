using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ImportResponseLoader : BaseResponseLoader
    {
        private readonly ImportClient _client;

        public ImportResponseLoader()
        {
            _client = new ImportClient();
        }

        public async Task<Stream> GetStreamFromSaveAnnouncementResponseAsync(Announcement announcement)
        {
            return await GetStreamFromResponseAsync(await _client.SaveAnnouncementAsync(announcement));
        }
    }
}
