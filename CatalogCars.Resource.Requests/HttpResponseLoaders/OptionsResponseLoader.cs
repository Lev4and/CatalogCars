using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class OptionsResponseLoader : BaseResponseLoader
    {
        private readonly OptionsClient _client;

        public OptionsResponseLoader()
        {
            _client = new OptionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountOptionsResponseAsync(OptionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountOptionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesOptionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesOptionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetOptionsResponseAsync(OptionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetOptionsAsync(filters));
        }
    }
}
