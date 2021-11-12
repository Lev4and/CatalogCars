using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class LocationsRequester
    {
        private readonly LocationsResponseLoader _responseLoader;

        public LocationsRequester()
        {
            _responseLoader = new LocationsResponseLoader();
        }

        public async Task<int> GetCountLocationsAsync(LocationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountLocationsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesLocationsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesLocationsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Location[]> GetLocationsAsync(LocationsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetLocationsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Location[]>(await stream.ReadToEndAsync());
                }
            }

            return new Location[0];
        }

        public async Task<bool> ContainsLocationAsync(double latitude, double longitude)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsLocationResponseAsync(latitude, longitude);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Location> GetLocationAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetLocationResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Location>(await stream.ReadToEndAsync());
                }
            }

            return new Location();
        }

        public async Task<SaveResult<object>> AddLocationAsync(Location location)
        {
            var resultStream = await _responseLoader.GetStreamFromAddLocationResponseAsync(location);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateLocationAsync(Location location)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateLocationResponseAsync(location);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteLocationAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteLocationResponseAsync(id);
        }
    }
}
