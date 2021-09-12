using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ImportRequester
    {
        private readonly ImportResponseLoader _responseLoader;

        public ImportRequester()
        {
            _responseLoader = new ImportResponseLoader();
        }

        public async Task<bool> SaveAnnouncementAsync(Announcement announcement)
        {
            var resultStream = await _responseLoader.GetStreamFromSaveAnnouncementResponseAsync(announcement);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
