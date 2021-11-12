using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class SteeringWheelsRequester
    {
        private readonly SteeringWheelsResponseLoader _responseLoader;

        public SteeringWheelsRequester()
        {
            _responseLoader = new SteeringWheelsResponseLoader();
        }

        public async Task<int> GetCountSteeringWheelsAsync(SteeringWheelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountSteeringWheelsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesSteeringWheelsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesSteeringWheelsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<SteeringWheel[]> GetSteeringWheelsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetSteeringWheelsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SteeringWheel[]>(await stream.ReadToEndAsync());
                }
            }

            return new SteeringWheel[0];
        }

        public async Task<SteeringWheel[]> GetSteeringWheelsAsync(SteeringWheelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSteeringWheelsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SteeringWheel[]>(await stream.ReadToEndAsync());
                }
            }

            return new SteeringWheel[0];
        }

        public async Task<bool> ContainsSteeringWheelAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsSteeringWheelResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<SteeringWheel> GetSteeringWheelAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSteeringWheelResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SteeringWheel>(await stream.ReadToEndAsync());
                }
            }

            return new SteeringWheel();
        }

        public async Task<SaveResult<object>> AddSteeringWheelAsync(SteeringWheel steeringWheel)
        {
            var resultStream = await _responseLoader.GetStreamFromAddSteeringWheelResponseAsync(steeringWheel);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateSteeringWheelAsync(SteeringWheel steeringWheel)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateSteeringWheelResponseAsync(steeringWheel);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteSteeringWheelAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteSteeringWheelResponseAsync(id);
        }
    }
}
