using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class SalonsRequester
    {
        private readonly SalonsResponseLoader _responseLoader;

        public SalonsRequester()
        {
            _responseLoader = new SalonsResponseLoader();
        }

        public async Task<int> GetCountSalonsAsync(SalonsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountSalonsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<DateTime> GetMinRegistrationDateSalonAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMinRegistrationDateSalonResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<DateTime>(await stream.ReadToEndAsync());
                }
            }

            return DateTime.MinValue;
        }

        public async Task<DateTime> GetMaxRegistrationDateSalonAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetMaxRegistrationDateSalonResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<DateTime>(await stream.ReadToEndAsync());
                }
            }

            return DateTime.MaxValue;
        }

        public async Task<string[]> GetNamesSalonsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesSalonsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Salon[]> GetSalonsAsync(SalonsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSalonsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Salon[]>(await stream.ReadToEndAsync());
                }
            }

            return new Salon[0];
        }

        public async Task<bool> ContainsSalonAsync(Guid locationId, string name)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsSalonResponseAsync(locationId, name);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Salon> GetSalonAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSalonResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Salon>(await stream.ReadToEndAsync());
                }
            }

            return new Salon();
        }

        public async Task<SaveResult<object>> AddSalonAsync(Salon salon)
        {
            var resultStream = await _responseLoader.GetStreamFromAddSalonResponseAsync(salon);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateSalonAsync(Salon salon)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateSalonResponseAsync(salon);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteSalonAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteSalonResponseAsync(id);
        }
    }
}
