using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class SellerTypesResponseLoader : BaseResponseLoader
    {
        private readonly SellerTypesClient _client;

        public SellerTypesResponseLoader()
        {
            _client = new SellerTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountSellerTypesResponseAsync(SellerTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountSellerTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesSellerTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesSellerTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetSellerTypesResponseAsync(SellerTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSellerTypesAsync(filters));
        }
    }
}
