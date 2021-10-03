using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PhonesResponseLoader : BaseResponseLoader
    {
        private readonly PhonesClient _client;

        public PhonesResponseLoader()
        {
            _client = new PhonesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPhonesResponseAsync(PhonesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPhonesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPhonesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPhonesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPhonesResponseAsync(PhonesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhonesAsync(filters));
        }
    }
}
