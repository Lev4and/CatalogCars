using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PhonesResponseLoader : BaseResponseLoader
    {
        private readonly PhonesClient _client;

        public PhonesResponseLoader()
        {
            _client = new PhonesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPhonesResponseAsync(PhonesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPhonesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPhonesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPhonesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPhonesResponseAsync(PhonesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhonesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsPhoneResponseAsync(string value)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsPhoneAsync(value));
        }

        public async Task<Stream> GetStreamFromGetPhoneResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhoneAsync(id));
        }

        public async Task<Stream> GetStreamFromAddPhoneResponseAsync(Phone phone)
        {
            return await GetStreamFromResponseAsync(await _client.AddPhoneAsync(phone));
        }

        public async Task<Stream> GetStreamFromUpdatePhoneResponseAsync(Phone phone)
        {
            return await GetStreamFromResponseAsync(await _client.UpdatePhoneAsync(phone));
        }

        public async Task<Stream> GetStreamFromDeletePhoneResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeletePhoneAsync(id));
        }
    }
}
