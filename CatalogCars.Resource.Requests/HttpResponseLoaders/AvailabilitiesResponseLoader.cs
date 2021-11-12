using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class AvailabilitiesResponseLoader : BaseResponseLoader
    {
        private readonly AvailabilitiesClient _client;

        public AvailabilitiesResponseLoader()
        {
            _client = new AvailabilitiesClient();
        }

        public async Task<Stream> GetStreamFromGetCountAvailabilitiesResponseAsync(AvailabilitiesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountAvailabilitiesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesAvailabilitiesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesAvailabilitiesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetAvailabilitiesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetAvailabilitiesAsync());
        }

        public async Task<Stream> GetStreamFromGetAvailabilitiesResponseAsync(AvailabilitiesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetAvailabilitiesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsAvailabilityResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsAvailabilityAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetAvailabilityResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetAvailabilityAsync(id));
        }

        public async Task<Stream> GetStreamFromAddAvailabilityResponseAsync(Availability availability)
        {
            return await GetStreamFromResponseAsync(await _client.AddAvailabilityAsync(availability));
        }

        public async Task<Stream> GetStreamFromUpdateAvailabilityResponseAsync(Availability availability)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateAvailabilityAsync(availability));
        }

        public async Task<Stream> GetStreamFromDeleteAvailabilityResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteAvailabilityAsync(id));
        }
    }
}
