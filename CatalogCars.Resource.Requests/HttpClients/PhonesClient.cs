using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PhonesClient : BaseHttpClient
    {
        public PhonesClient() : base("phones/")
        {

        }

        public async Task<HttpResponseMessage> GetCountPhonesAsync(PhonesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesPhonesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPhonesAsync(PhonesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsPhoneAsync(string value)
        {
            return await _client.GetAsync($"contains?value={value}");
        }

        public async Task<HttpResponseMessage> GetPhoneAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddPhoneAsync(Phone phone)
        {
            return await _client.PostAsync("add", new StringContent(JsonConvert.SerializeObject(phone),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdatePhoneAsync(Phone phone)
        {
            return await _client.PutAsync("update", new StringContent(JsonConvert.SerializeObject(phone),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeletePhoneAsync(Guid id)
        {
            return await _client.DeleteAsync($"delete?id={id}");
        }
    }
}
