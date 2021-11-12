using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class CurrenciesRequester
    {
        private readonly CurrenciesResponseLoader _responseLoader;

        public CurrenciesRequester()
        {
            _responseLoader = new CurrenciesResponseLoader();
        }

        public async Task<int> GetCountCurrenciesAsync(CurrenciesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountCurrenciesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesCurrenciesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesCurrenciesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Currency[]> GetCurrenciesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetCurrenciesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Currency[]>(await stream.ReadToEndAsync());
                }
            }

            return new Currency[0];
        }

        public async Task<Currency[]> GetCurrenciesAsync(CurrenciesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCurrenciesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Currency[]>(await stream.ReadToEndAsync());
                }
            }

            return new Currency[0];
        }

        public async Task<bool> ContainsCurrencyAsync(string name)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsCurrencyResponseAsync(name);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Currency> GetCurrencyAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCurrencyResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Currency>(await stream.ReadToEndAsync());
                }
            }

            return new Currency();
        }

        public async Task<SaveResult<object>> AddCurrencyAsync(Currency currency)
        {
            var resultStream = await _responseLoader.GetStreamFromAddCurrencyResponseAsync(currency);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateCurrencyAsync(Currency currency)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateCurrencyResponseAsync(currency);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteCurrencyAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteCurrencyResponseAsync(id);
        }
    }
}
