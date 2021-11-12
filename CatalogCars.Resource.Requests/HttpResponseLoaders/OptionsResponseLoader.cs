using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class OptionsResponseLoader : BaseResponseLoader
    {
        private readonly OptionsClient _client;

        public OptionsResponseLoader()
        {
            _client = new OptionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountOptionsResponseAsync(OptionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountOptionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesOptionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesOptionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetOptionsResponseAsync(OptionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetOptionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsOptionResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsOptionAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetOptionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetOptionAsync(id));
        }

        public async Task<Stream> GetStreamFromAddOptionResponseAsync(Option option)
        {
            return await GetStreamFromResponseAsync(await _client.AddOptionAsync(option));
        }

        public async Task<Stream> GetStreamFromUpdateOptionResponseAsync(Option option)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateOptionAsync(option));
        }

        public async Task<Stream> GetStreamFromDeleteOptionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteOptionAsync(id));
        }
    }
}
