using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
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
    }
}
