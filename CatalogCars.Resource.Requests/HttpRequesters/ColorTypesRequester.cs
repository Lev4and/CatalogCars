using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ColorTypesRequester
    {
        private readonly ColorTypesResponseLoader _responseLoader;

        public ColorTypesRequester()
        {
            _responseLoader = new ColorTypesResponseLoader();
        }

        public async Task<int> GetCountColorTypesAsync(ColorTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountColorTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesColorTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesColorTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<ColorType[]> GetColorTypesAsync(ColorTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetColorTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<ColorType[]>(await stream.ReadToEndAsync());
                }
            }

            return new ColorType[0];
        }

        public async Task<bool> ContainsColorTypeAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsColorTypeResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<ColorType> GetColorTypeAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetColorTypeResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<ColorType>(await stream.ReadToEndAsync());
                }
            }

            return new ColorType();
        }

        public async Task<SaveResult<object>> AddColorTypeAsync(ColorType colorType)
        {
            var resultStream = await _responseLoader.GetStreamFromAddColorTypeResponseAsync(colorType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateColorTypeAsync(ColorType colorType)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateColorTypeResponseAsync(colorType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteColorTypeAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteColorTypeResponseAsync(id);
        }
    }
}
