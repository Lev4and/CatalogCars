using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PriceSegmentsClient : BaseHttpClient
    {
        public PriceSegmentsClient() : base("priceSegments/")
        {

        }

        public async Task<HttpResponseMessage> GetCountPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesPriceSegmentsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPriceSegmentsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> ContainsPriceSegmentAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetPriceSegmentAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddPriceSegmentAsync(PriceSegment priceSegment)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(priceSegment),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdatePriceSegmentAsync(PriceSegment priceSegment)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(priceSegment),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeletePriceSegmentAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
