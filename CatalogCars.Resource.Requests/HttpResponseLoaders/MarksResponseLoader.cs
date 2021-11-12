using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class MarksResponseLoader : BaseResponseLoader
    {
        private readonly MarksClient _client;

        public MarksResponseLoader()
        {
            _client = new MarksClient();
        }

        public async Task<Stream> GetStreamFromGetCountMarksResponseAsync(MarksFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountMarksAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesMarksResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesMarksAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetMarksResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetMarksAsync());
        }

        public async Task<Stream> GetStreamFromGetMarksResponseAsync(MarksFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetMarksAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetMarkResponseAsync(Guid markId)
        {
            return await GetStreamFromResponseAsync(await _client.GetMarkAsync(markId));
        }

        public async Task<Stream> GetStreamFromGetPopularityMarkResponseAsync(Guid markId)
        {
            return await GetStreamFromResponseAsync(await _client.GetPopularityMark(markId));
        }

        public async Task<Stream> GetStreamFromContainsMarkResponseAsync(string name)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsMarkAsync(name));
        }

        public async Task<Stream> GetStreamFromAddMarkResponseAsync(Mark mark)
        {
            return await GetStreamFromResponseAsync(await _client.AddMarkAsync(mark));
        }

        public async Task<Stream> GetStreamFromUpdateMarkResponseAsync(Mark mark)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateMarkAsync(mark));
        }

        public async Task<Stream> GetStreamFromDeleteMarkResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteMarkAsync(id));
        }
    }
}
