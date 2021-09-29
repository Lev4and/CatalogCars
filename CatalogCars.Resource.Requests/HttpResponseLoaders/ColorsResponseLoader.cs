using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ColorsResponseLoader : BaseResponseLoader
    {
        private readonly ColorsClient _client;

        public ColorsResponseLoader()
        {
            _client = new ColorsClient();
        }

        public async Task<Stream> GetStreamFromGetCountColorsResponseAsync(ColorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountColorsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesColorsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesColorsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetColorsResponseAsync(ColorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorsAsync(filters));
        }
    }
}
