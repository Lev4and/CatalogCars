using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromGetVendorsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetVendorsAsync());
        }

        public async Task<Stream> GetStreamFromGetVendorsResponseAsync(VendorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetVendorsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsVendorResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsVendorAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetVendorResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetVendorAsync(id));
        }

        public async Task<Stream> GetStreamFromAddVendorResponseAsync(Vendor vendor)
        {
            return await GetStreamFromResponseAsync(await _client.AddVendorAsync(vendor));
        }

        public async Task<Stream> GetStreamFromUpdateVendorResponseAsync(Vendor vendor)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateVendorAsync(vendor));
        }

        public async Task<Stream> GetStreamFromDeleteVendorResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteVendorAsync(id));
        }
    }
}
