using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class SalonsResponseLoader : BaseResponseLoader
    {
        private readonly SalonsClient _client;

        public SalonsResponseLoader()
        {
            _client = new SalonsClient();
        }

        public async Task<Stream> GetStreamFromGetCountSalonsResponseAsync(SalonsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountSalonsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetMinRegistrationDateSalonResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMinRegistrationDateSalonAsync());
        }

        public async Task<Stream> GetStreamFromGetMaxRegistrationDateSalonResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMaxRegistrationDateSalonAsync());
        }

        public async Task<Stream> GetStreamFromGetNamesSalonsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesSalonsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetSalonsResponseAsync(SalonsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSalonsAsync(filters));
        }
    }
}
