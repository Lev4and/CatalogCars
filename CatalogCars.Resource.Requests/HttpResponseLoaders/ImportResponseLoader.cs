using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ImportResponseLoader
    {
        private readonly ImportClient _client;

        public ImportResponseLoader()
        {
            _client = new ImportClient();
        }

        public async Task<Stream> GetStreamAsync(Announcement announcement)
        {
            var response = await _client.SaveAnnouncementAsync(announcement);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStreamAsync();
                }
            }

            return null;
        }
    }
}
