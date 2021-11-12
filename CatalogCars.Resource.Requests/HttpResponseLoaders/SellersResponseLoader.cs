using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromContainsSellerResponseAsync(Guid locationId)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsSellerAsync(locationId));
        }

        public async Task<Stream> GetStreamFromGetSellerResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetSellerAsync(id));
        }

        public async Task<Stream> GetStreamFromAddSellerResponseAsync(Seller seller)
        {
            return await GetStreamFromResponseAsync(await _client.AddSellerAsync(seller));
        }

        public async Task<Stream> GetStreamFromUpdateSellerResponseAsync(Seller seller)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateSellerAsync(seller));
        }

        public async Task<Stream> GetStreamFromDeleteSellerResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteSellerAsync(id));
        }
    }
}
