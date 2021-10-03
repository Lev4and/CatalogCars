using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class SellersResponseLoader : BaseResponseLoader
    {
        private readonly SellersClient _client;

        public SellersResponseLoader()
        {
            _client = new SellersClient();
        }

        public async Task<Stream> GetStreamFromGetCountSellersResponseAsync(SellersFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountSellersAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesSellersResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesSellersAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetSellersResponseAsync(SellersFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSellersAsync(filters));
        }
    }
}
