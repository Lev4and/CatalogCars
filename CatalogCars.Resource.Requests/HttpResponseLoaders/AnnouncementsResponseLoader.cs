using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class AnnouncementsResponseLoader : BaseResponseLoader
    {
        private readonly AnnouncementsClient _client;

        public AnnouncementsResponseLoader()
        {
            _client = new AnnouncementsClient();
        }

        public async Task<Stream> GetStreamFromGetCountAnnouncementsResponseAsync(AnnouncementsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountAnnouncementsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesAnnouncementsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesAnnouncementsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetAnnouncementsResponseAsync(AnnouncementsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetAnnouncementsAsync(filters));
        }
    }
}
