using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PhonesRequester
    {
        private readonly PhonesResponseLoader _responseLoader;

        public PhonesRequester()
        {
            _responseLoader = new PhonesResponseLoader();
        }

        public async Task<int> GetCountPhonesAsync(PhonesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountPhonesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesPhonesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesPhonesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Phone[]> GetPhonesAsync(PhonesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPhonesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Phone[]>(await stream.ReadToEndAsync());
                }
            }

            return new Phone[0];
        }

        public async Task<bool> ContainsPhoneAsync(string value)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsPhoneResponseAsync(value);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Phone> GetPhoneAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPhoneResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Phone>(await stream.ReadToEndAsync());
                }
            }

            return new Phone();
        }

        public async Task<SaveResult<object>> AddPhoneAsync(Phone phone)
        {
            var resultStream = await _responseLoader.GetStreamFromAddPhoneResponseAsync(phone);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdatePhoneAsync(Phone phone)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdatePhoneResponseAsync(phone);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeletePhoneAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeletePhoneResponseAsync(id);
        }
    }
}
