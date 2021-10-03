using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PhotoClassesResponseLoader : BaseResponseLoader
    {
        private readonly PhotoClassesClient _client;

        public PhotoClassesResponseLoader()
        {
            _client = new PhotoClassesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPhotoClassesResponseAsync(PhotoClassesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPhotoClassesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPhotoClassesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPhotoClassesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPhotoClassesResponseAsync(PhotoClassesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhotoClassesAsync(filters));
        }
    }
}
