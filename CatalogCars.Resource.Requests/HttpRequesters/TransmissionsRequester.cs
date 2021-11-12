using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
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

        public async Task<bool> ContainsTransmissionAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsTransmissionResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Transmission> GetTransmissionAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetTransmissionResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Transmission>(await stream.ReadToEndAsync());
                }
            }

            return new Transmission();
        }

        public async Task<SaveResult<object>> AddTransmissionAsync(Transmission transmission)
        {
            var resultStream = await _responseLoader.GetStreamFromAddTransmissionResponseAsync(transmission);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateTransmissionAsync(Transmission transmission)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateTransmissionResponseAsync(transmission);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteTransmissionAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteTransmissionResponseAsync(id);
        }
    }
}
