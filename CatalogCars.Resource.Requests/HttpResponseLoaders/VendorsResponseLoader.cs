using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class VendorsResponseLoader : BaseResponseLoader
    {
        private readonly VendorsClient _client;

        public VendorsResponseLoader()
        {
            _client = new VendorsClient();
        }

        public async Task<Stream> GetStreamFromGetCountVendorsResponseAsync(VendorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountVendorsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesVendorsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesVendorsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetVendorsResponseAsync(VendorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetVendorsAsync(filters));
        }
    }
}
