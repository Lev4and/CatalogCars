using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class StatusesResponseLoader : BaseResponseLoader
    {
        private readonly StatusesClient _client;

        public StatusesResponseLoader()
        {
            _client = new StatusesClient();
        }

        public async Task<Stream> GetStreamFromGetCountStatusesResponseAsync(StatusesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountStatusesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesStatusesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesStatusesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetStatusesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetStatusesAsync());
        }

        public async Task<Stream> GetStreamFromGetStatusesResponseAsync(StatusesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetStatusesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsStatusResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsStatusAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetStatusResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetStatusAsync(id));
        }

        public async Task<Stream> GetStreamFromAddStatusResponseAsync(Status status)
        {
            return await GetStreamFromResponseAsync(await _client.AddStatusAsync(status));
        }

        public async Task<Stream> GetStreamFromUpdateStatusResponseAsync(Status status)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateStatusAsync(status));
        }

        public async Task<Stream> GetStreamFromDeleteStatusResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteStatusAsync(id));
        }
    }
}
