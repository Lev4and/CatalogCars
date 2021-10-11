using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class TransmissionsRequester
    {
        private readonly TransmissionsResponseLoader _responseLoader;

        public TransmissionsRequester()
        {
            _responseLoader = new TransmissionsResponseLoader();
        }

        public async Task<int> GetCountTransmissionsAsync(TransmissionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountTransmissionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesTransmissionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesTransmissionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Transmission[]> GetTransmissionsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetTransmissionsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Transmission[]>(await stream.ReadToEndAsync());
                }
            }

            return new Transmission[0];
        }

        public async Task<Transmission[]> GetTransmissionsAsync(TransmissionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetTransmissionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Transmission[]>(await stream.ReadToEndAsync());
                }
            }

            return new Transmission[0];
        }
    }
}
