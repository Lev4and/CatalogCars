using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromGetSellerTypesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetSellerTypesAsync());
        }

        public async Task<Stream> GetStreamFromGetSellerTypesResponseAsync(SellerTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSellerTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsSellerTypeResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsSellerTypeAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetSellerTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetSellerTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddSellerTypeResponseAsync(SellerType sellerType)
        {
            return await GetStreamFromResponseAsync(await _client.AddSellerTypeAsync(sellerType));
        }

        public async Task<Stream> GetStreamFromUpdateSellerTypeResponseAsync(SellerType sellerType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateSellerTypeAsync(sellerType));
        }

        public async Task<Stream> GetStreamFromDeleteSellerTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteSellerTypeAsync(id));
        }
    }
}
