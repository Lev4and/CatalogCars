using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class OptionsRequester
    {
        private readonly OptionsResponseLoader _responseLoader;

        public OptionsRequester()
        {
            _responseLoader = new OptionsResponseLoader();
        }

        public async Task<int> GetCountOptionsAsync(OptionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountOptionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesOptionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesOptionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Option[]> GetOptionsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetOptionsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Option[]>(await stream.ReadToEndAsync());
                }
            }

            return new Option[0];
        }

        public async Task<Option[]> GetOptionsAsync(OptionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetOptionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Option[]>(await stream.ReadToEndAsync());
                }
            }

            return new Option[0];
        }

        public async Task<bool> ContainsOptionAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsOptionResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Option> GetOptionAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetOptionResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Option>(await stream.ReadToEndAsync());
                }
            }

            return new Option();
        }

        public async Task<SaveResult<object>> AddOptionAsync(Option option)
        {
            var resultStream = await _responseLoader.GetStreamFromAddOptionResponseAsync(option);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateOptionAsync(Option option)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateOptionResponseAsync(option);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteOptionAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteOptionResponseAsync(id);
        }
    }
}
