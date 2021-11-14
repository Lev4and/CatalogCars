using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PtsTypesClient : BaseHttpClient
    {
        public PtsTypesClient() : base("ptsTypes/")
        {

        }

        public async Task<HttpResponseMessage> GetCountPtsTypesAsync(PtsTypesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesPtsTypesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPtsTypesAsync(PtsTypesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsPtsTypeAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetPtsTypeAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddPtsTypeAsync(PtsType ptsType)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(ptsType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdatePtsTypeAsync(PtsType ptsType)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(ptsType),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeletePtsTypeAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
