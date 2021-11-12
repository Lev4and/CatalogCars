using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ColorsResponseLoader : BaseResponseLoader
    {
        private readonly ColorsClient _client;

        public ColorsResponseLoader()
        {
            _client = new ColorsClient();
        }

        public async Task<Stream> GetStreamFromGetCountColorsResponseAsync(ColorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountColorsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesColorsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesColorsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetColorsResponseAsync(ColorsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorsAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsColorResponseAsync(string value)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsColorAsync(value));
        }

        public async Task<Stream> GetStreamFromGetColorResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorAsync(id));
        }

        public async Task<Stream> GetStreamFromAddColorResponseAsync(Color color)
        {
            return await GetStreamFromResponseAsync(await _client.AddColorAsync(color));
        }

        public async Task<Stream> GetStreamFromUpdateColorResponseAsync(Color color)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateColorAsync(color));
        }

        public async Task<Stream> GetStreamFromDeleteColorResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteColorAsync(id));
        }
    }
}
