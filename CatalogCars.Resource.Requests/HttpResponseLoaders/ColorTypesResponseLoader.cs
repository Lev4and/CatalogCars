using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ColorTypesResponseLoader : BaseResponseLoader
    {
        private readonly ColorTypesClient _client;

        public ColorTypesResponseLoader()
        {
            _client = new ColorTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountColorTypesResponseAsync(ColorTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountColorTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesColorTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesColorTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetColorTypesResponseAsync(ColorTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorTypesAsync(filters));
        }
    }
}
