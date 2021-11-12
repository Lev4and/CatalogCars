using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class SectionsRequester
    {
        private readonly SectionsResponseLoader _responseLoader;

        public SectionsRequester()
        {
            _responseLoader = new SectionsResponseLoader();
        }

        public async Task<int> GetCountSectionsAsync(SectionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountSectionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesSectionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesSectionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Section[]> GetSectionsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetSectionsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Section[]>(await stream.ReadToEndAsync());
                }
            }

            return new Section[0];
        }

        public async Task<Section[]> GetSectionsAsync(SectionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSectionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Section[]>(await stream.ReadToEndAsync());
                }
            }

            return new Section[0];
        }

        public async Task<bool> ContainsSectionAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsSectionResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Section> GetSectionAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSectionResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Section>(await stream.ReadToEndAsync());
                }
            }

            return new Section();
        }

        public async Task<SaveResult<object>> AddSectionAsync(Section section)
        {
            var resultStream = await _responseLoader.GetStreamFromAddSectionResponseAsync(section);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateSectionAsync(Section section)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateSectionResponseAsync(section);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteSectionAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteSectionResponseAsync(id);
        }
    }
}
