﻿using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class MarksRequester
    {
        private readonly MarksResponseLoader _responseLoader;

        public MarksRequester()
        {
            _responseLoader = new MarksResponseLoader();
        }

        public async Task<int> GetCountMarksAsync(MarksFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesMarksAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesMarksResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Mark[]> GetMarksAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMarksResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Mark[]>(await stream.ReadToEndAsync());
                }
            }

            return new Mark[0];
        }

        public async Task<Mark[]> GetMarksAsync(MarksFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Mark[]>(await stream.ReadToEndAsync());
                }
            }

            return new Mark[0];
        }

        public async Task<Mark> GetMarkAsync(Guid markId)
        {
            var resultStream = await _responseLoader.GetStreamFromGetMarkResponseAsync(markId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Mark>(await stream.ReadToEndAsync());
                }
            }

            return new Mark();
        }

        public async Task<PopularityMark[]> GetPopularityMarkAsync(Guid markId)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPopularityMarkResponseAsync(markId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PopularityMark[]>(await stream.ReadToEndAsync());
                }
            }

            return new PopularityMark[0];
        }

        public async Task<bool> ContainsMarkAsync(string name)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsMarkResponseAsync(name);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<SaveResult<object>> AddMarkAsync(Mark mark)
        {
            var resultStream = await _responseLoader.GetStreamFromAddMarkResponseAsync(mark);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateMarkAsync(Mark mark)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateMarkResponseAsync(mark);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteMarkAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteMarkResponseAsync(id);
        }

        public async Task<PopularMark[]> GetPopularMarksAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetPopularMarksResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PopularMark[]>(await stream.ReadToEndAsync());
                }
            }

            return new PopularMark[0];
        }
    }
}
