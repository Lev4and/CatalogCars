using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class GearTypesRequester
    {
        private readonly GearTypesResponseLoader _responseLoader;

        public GearTypesRequester()
        {
            _responseLoader = new GearTypesResponseLoader();
        }

        public async Task<int> GetCountGearTypesAsync(GearTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountGearTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesGearTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesGearTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<GearType[]> GetGearTypesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetGearTypesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<GearType[]>(await stream.ReadToEndAsync());
                }
            }

            return new GearType[0];
        }

        public async Task<GearType[]> GetGearTypesAsync(GearTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetGearTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<GearType[]>(await stream.ReadToEndAsync());
                }
            }

            return new GearType[0];
        }

        public async Task<bool> ContainsGearTypeAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsGearTypeResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<GearType> GetGearTypeAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetGearTypeResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<GearType>(await stream.ReadToEndAsync());
                }
            }

            return new GearType();
        }

        public async Task<SaveResult<object>> AddGearTypeAsync(GearType gearType)
        {
            var resultStream = await _responseLoader.GetStreamFromAddGearTypeResponseAsync(gearType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateGearTypeAsync(GearType gearType)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateGearTypeResponseAsync(gearType);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteGearTypeAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteGearTypeResponseAsync(id);
        }
    }
}
