using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class CurrenciesResponseLoader : BaseResponseLoader
    {
        private readonly CurrenciesClient _client;

        public CurrenciesResponseLoader()
        {
            _client = new CurrenciesClient();
        }

        public async Task<Stream> GetStreamFromGetCountCurrenciesResponseAsync(CurrenciesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountCurrenciesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesCurrenciesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesCurrenciesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetCurrenciesResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetCurrenciesAsync());
        }

        public async Task<Stream> GetStreamFromGetCurrenciesResponseAsync(CurrenciesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCurrenciesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsCurrencyResponseAsync(string name)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsCurrencyAsync(name));
        }

        public async Task<Stream> GetStreamFromGetCurrencyResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetCurrencyAsync(id));
        }

        public async Task<Stream> GetStreamFromAddCurrencyResponseAsync(Currency currency)
        {
            return await GetStreamFromResponseAsync(await _client.AddCurrencyAsync(currency));
        }

        public async Task<Stream> GetStreamFromUpdateCurrencyResponseAsync(Currency currency)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateCurrencyAsync(currency));
        }

        public async Task<Stream> GetStreamFromDeleteCurrencyResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteCurrencyAsync(id));
        }
    }
}
