using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class VendorsClient : BaseHttpClient
    {
        public VendorsClient() : base("vendors/")
        {

        }

        public async Task<HttpResponseMessage> GetCountVendorsAsync(VendorsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesVendorsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetVendorsAsync(VendorsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsVendorAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetVendorAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddVendorAsync(Vendor vendor)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(vendor),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateVendorAsync(Vendor vendor)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(vendor),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteVendorAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
