using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class EngineTypesRequester
    {
        private readonly EngineTypesResponseLoader _responseLoader;

        public EngineTypesRequester()
        {
            _responseLoader = new EngineTypesResponseLoader();
        }

        public async Task<int> GetCountEngineTypesAsync(EngineTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountEngineTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesEngineTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesEngineTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<EngineType[]> GetEngineTypesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetEngineTypesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<EngineType[]>(await stream.ReadToEndAsync());
                }
            }

            return new EngineType[0];
        }

        public async Task<EngineType[]> GetEngineTypesAsync(EngineTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetEngineTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<EngineType[]>(await stream.ReadToEndAsync());
                }
            }

            return new EngineType[0];
        }

        public async Task<bool> ContainsEngineTypeAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsEngineTypeResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<EngineType> GetEngineTypeAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetEngineTypeResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<EngineType>(await stream.ReadToEndAsync());
                }
            }

            return new EngineType();
        }

        public async Task<SaveResult<object>> AddEngineTypeAsync(EngineType engineType)
        {
            var resultStream = await _responseLoader.GetStreamFromAddEngineTypeResponseAsync(engineType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateEngineTypeAsync(EngineType engineType)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateEngineTypeResponseAsync(engineType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteEngineTypeAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteEngineTypeResponseAsync(id);
        }
    }
}
