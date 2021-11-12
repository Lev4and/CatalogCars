using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class SteeringWheelsResponseLoader : BaseResponseLoader
    {
        private readonly SteeringWheelsClient _client;

        public SteeringWheelsResponseLoader()
        {
            _client = new SteeringWheelsClient();
        }

        public async Task<Stream> GetStreamFromGetCountSteeringWheelsResponseAsync(SteeringWheelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountSteeringWheelsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesSteeringWheelsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesSteeringWheelsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetSteeringWheelsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetSteeringWheelsAsync());
        }

        public async Task<Stream> GetStreamFromGetSteeringWheelsResponseAsync(SteeringWheelsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSteeringWheelsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsSteeringWheelResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsSteeringWheelAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetSteeringWheelResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetSteeringWheelAsync(id));
        }

        public async Task<Stream> GetStreamFromAddSteeringWheelResponseAsync(SteeringWheel steeringWheel)
        {
            return await GetStreamFromResponseAsync(await _client.AddSteeringWheelAsync(steeringWheel));
        }

        public async Task<Stream> GetStreamFromUpdateSteeringWheelResponseAsync(SteeringWheel steeringWheel)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateSteeringWheelAsync(steeringWheel));
        }

        public async Task<Stream> GetStreamFromDeleteSteeringWheelResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteSteeringWheelAsync(id));
        }
    }
}
