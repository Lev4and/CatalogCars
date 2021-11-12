using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class AvailabilitiesRequester
    {
        private readonly AvailabilitiesResponseLoader _responseLoader;

        public AvailabilitiesRequester()
        {
            _responseLoader = new AvailabilitiesResponseLoader();
        }

        public async Task<int> GetCountAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountAvailabilitiesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesAvailabilitiesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesAvailabilitiesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Availability[]> GetAvailabilitiesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetAvailabilitiesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Availability[]>(await stream.ReadToEndAsync());
                }
            }

            return new Availability[0];
        }

        public async Task<Availability[]> GetAvailabilitiesAsync(AvailabilitiesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetAvailabilitiesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Availability[]>(await stream.ReadToEndAsync());
                }
            }

            return new Availability[0];
        }

        public async Task<bool> ContainsAvailabilityAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsAvailabilityResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Availability> GetAvailabilityAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetAvailabilityResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Availability>(await stream.ReadToEndAsync());
                }
            }

            return new Availability();
        }

        public async Task<SaveResult<object>> AddAvailabilityAsync(Availability availability)
        {
            var resultStream = await _responseLoader.GetStreamFromAddAvailabilityResponseAsync(availability);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateAvailabilityAsync(Availability availability)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateAvailabilityResponseAsync(availability);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteAvailabilityAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteAvailabilityResponseAsync(id);
        }
    }
}
