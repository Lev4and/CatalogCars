using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
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
    }
}
