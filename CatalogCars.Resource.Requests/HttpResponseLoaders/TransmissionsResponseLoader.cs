using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class TransmissionsResponseLoader : BaseResponseLoader
    {
        private readonly TransmissionsClient _client;

        public TransmissionsResponseLoader()
        {
            _client = new TransmissionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountTransmissionsResponseAsync(TransmissionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountTransmissionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesTransmissionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesTransmissionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetTransmissionsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetTransmissionsAsync());
        }

        public async Task<Stream> GetStreamFromGetTransmissionsResponseAsync(TransmissionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetTransmissionsAsync(filters));
        }
    }
}
