using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class VendorsRequester
    {
        private readonly VendorsResponseLoader _responseLoader;

        public VendorsRequester()
        {
            _responseLoader = new VendorsResponseLoader();
        }

        public async Task<int> GetCountVendorsAsync(VendorsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountVendorsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesVendorsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesVendorsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Vendor[]> GetVendorsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetVendorsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Vendor[]>(await stream.ReadToEndAsync());
                }
            }

            return new Vendor[0];
        }

        public async Task<Vendor[]> GetVendorsAsync(VendorsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetVendorsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Vendor[]>(await stream.ReadToEndAsync());
                }
            }

            return new Vendor[0];
        }

        public async Task<bool> ContainsVendorAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsVendorResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Vendor> GetVendorAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetVendorResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Vendor>(await stream.ReadToEndAsync());
                }
            }

            return new Vendor();
        }

        public async Task<SaveResult<object>> AddVendorAsync(Vendor vendor)
        {
            var resultStream = await _responseLoader.GetStreamFromAddVendorResponseAsync(vendor);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateVendorAsync(Vendor vendor)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateVendorResponseAsync(vendor);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteVendorAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteVendorResponseAsync(id);
        }
    }
}
