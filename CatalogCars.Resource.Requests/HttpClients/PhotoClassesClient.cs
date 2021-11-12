using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class PhotoClassesClient : BaseHttpClient
    {
        public PhotoClassesClient() : base("photoClasses/")
        {

        }

        public async Task<HttpResponseMessage> GetCountPhotoClassesAsync(PhotoClassesFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesPhotoClassesAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetPhotoClassesAsync(PhotoClassesFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsPhotoClassAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetPhotoClassAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddPhotoClassAsync(PhotoClass photoClass)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(photoClass),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdatePhotoClassAsync(PhotoClass photoClass)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(photoClass),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeletePhotoClassAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
