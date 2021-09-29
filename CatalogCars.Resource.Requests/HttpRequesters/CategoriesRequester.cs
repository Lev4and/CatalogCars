using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class CategoriesRequester
    {
        private readonly CategoriesResponseLoader _responseLoader;

        public CategoriesRequester()
        {
            _responseLoader = new CategoriesResponseLoader();
        }

        public async Task<int> GetCountCategoriesAsync(CategoriesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountCategoriesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesCategoriesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesCategoriesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Category[]> GetCategoriesAsync(CategoriesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCategoriesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Category[]>(await stream.ReadToEndAsync());
                }
            }

            return new Category[0];
        }
    }
}
