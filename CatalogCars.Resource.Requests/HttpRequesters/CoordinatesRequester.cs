using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class CoordinatesRequester
    {
        private readonly CoordinatesResponseLoader _responseLoader;

        public CoordinatesRequester()
        {
            _responseLoader = new CoordinatesResponseLoader();
        }

        public async Task<int> GetCountCoordinatesAsync(CoordinatesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountCoordinatesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesCoordinatesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesCoordinatesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Coordinate[]> GetCoordinatesAsync(CoordinatesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCoordinatesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Coordinate[]>(await stream.ReadToEndAsync());
                }
            }

            return new Coordinate[0];
        }

        public async Task<bool> ContainsCoordinateAsync(Guid locationId, double latitude, double longitude)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsCoordinateResponseAsync(locationId, latitude, longitude);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Coordinate> GetCoordinateAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCoordinateResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Coordinate>(await stream.ReadToEndAsync());
                }
            }

            return new Coordinate();
        }

        public async Task<SaveResult<object>> AddCoordinateAsync(Coordinate coordinate)
        {
            var resultStream = await _responseLoader.GetStreamFromAddCoordinateResponseAsync(coordinate);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateCoordinateAsync(Coordinate coordinate)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateCoordinateResponseAsync(coordinate);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteCoordinateAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteCoordinateResponseAsync(id);
        }
    }
}
