using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class CurrenciesResponseLoader : BaseResponseLoader
    {
        private readonly CurrenciesClient _client;

        public CurrenciesResponseLoader()
        {
            _client = new CurrenciesClient();
        }

        public async Task<Stream> GetStreamFromGetCountCurrenciesResponseAsync(CurrenciesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountCurrenciesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesCurrenciesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesCurrenciesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetCurrenciesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetCurrenciesAsync());
        }

        public async Task<Stream> GetStreamFromGetCurrenciesResponseAsync(CurrenciesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCurrenciesAsync(filters));
        }
    }
}
