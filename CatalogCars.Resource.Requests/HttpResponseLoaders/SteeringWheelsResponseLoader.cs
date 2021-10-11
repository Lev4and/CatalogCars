using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
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
    }
}
