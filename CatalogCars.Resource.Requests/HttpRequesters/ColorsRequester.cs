using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ColorsRequester
    {
        private readonly ColorsResponseLoader _responseLoader;

        public ColorsRequester()
        {
            _responseLoader = new ColorsResponseLoader();
        }

        public async Task<int> GetCountColorsAsync(ColorsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountColorsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesColorsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesColorsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Color[]> GetColorsAsync(ColorsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetColorsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Color[]>(await stream.ReadToEndAsync());
                }
            }

            return new Color[0];
        }

        public async Task<bool> ContainsColorAsync(string value)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsColorResponseAsync(value);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Color> GetColorAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetColorResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Color>(await stream.ReadToEndAsync());
                }
            }

            return new Color();
        }

        public async Task<SaveResult<object>> AddColorAsync(Color color)
        {
            var resultStream = await _responseLoader.GetStreamFromAddColorResponseAsync(color);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateColorAsync(Color color)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateColorResponseAsync(color);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteColorAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteColorResponseAsync(id);
        }
    }
}
