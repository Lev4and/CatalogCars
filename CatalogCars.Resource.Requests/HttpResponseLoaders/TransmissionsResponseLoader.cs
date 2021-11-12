using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class TransmissionsResponseLoader : BaseResponseLoader
    {
        private readonly TransmissionsClient _client;

        public TransmissionsResponseLoader()
        {
            _client = new TransmissionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountTransmissionsResponseAsync(TransmissionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountTransmissionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesTransmissionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesTransmissionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetTransmissionsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetTransmissionsAsync());
        }

        public async Task<Stream> GetStreamFromGetTransmissionsResponseAsync(TransmissionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetTransmissionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsTransmissionResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsTransmissionAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetTransmissionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetTransmissionAsync(id));
        }

        public async Task<Stream> GetStreamFromAddTransmissionResponseAsync(Transmission transmission)
        {
            return await GetStreamFromResponseAsync(await _client.AddTransmissionAsync(transmission));
        }

        public async Task<Stream> GetStreamFromUpdateTransmissionResponseAsync(Transmission transmission)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateTransmissionAsync(transmission));
        }

        public async Task<Stream> GetStreamFromDeleteTransmissionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteTransmissionAsync(id));
        }
    }
}
