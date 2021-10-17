using CatalogCars.Model.Database.AuxiliaryTypes;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class MarksClient : BaseHttpClient
    {
        public MarksClient() : base("marks/")
        {

        }

        public async Task<HttpResponseMessage> GetCountMarksAsync(MarksFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesMarksAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMarksAsync(MarksFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters), 
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMarkAsync(Guid markId)
        {
            return await _client.GetAsync($"?markId={markId}");
        }

        public async Task<HttpResponseMessage> GetPopularityMark(Guid markId)
        {
            return await _client.GetAsync($"popularityMark/?markId={markId}");
        }
    }
}
