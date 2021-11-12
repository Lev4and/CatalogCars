using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class StatusesRequester
    {
        private readonly StatusesResponseLoader _responseLoader;

        public StatusesRequester()
        {
            _responseLoader = new StatusesResponseLoader();
        }

        public async Task<int> GetCountStatusesAsync(StatusesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountStatusesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesStatusesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesStatusesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Status[]> GetStatusesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetStatusesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Status[]>(await stream.ReadToEndAsync());
                }
            }

            return new Status[0];
        }

        public async Task<Status[]> GetStatusesAsync(StatusesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetStatusesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Status[]>(await stream.ReadToEndAsync());
                }
            }

            return new Status[0];
        }

        public async Task<bool> ContainsStatusAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsStatusResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Status> GetStatusAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetStatusResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Status>(await stream.ReadToEndAsync());
                }
            }

            return new Status();
        }

        public async Task<SaveResult<object>> AddStatusAsync(Status status)
        {
            var resultStream = await _responseLoader.GetStreamFromAddStatusResponseAsync(status);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateStatusAsync(Status status)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateStatusResponseAsync(status);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteStatusAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteStatusResponseAsync(id);
        }
    }
}
