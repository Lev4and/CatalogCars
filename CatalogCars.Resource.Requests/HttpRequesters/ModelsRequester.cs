using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class ModelsRequester
    {
        private readonly ModelsResponseLoader _responseLoader;

        public ModelsRequester()
        {
            _responseLoader = new ModelsResponseLoader();
        }

        public async Task<int> GetCountModelsAsync(ModelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountModelsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<int> GetCountModelsOfMarksAsync(ModelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountModelsOfMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesModelsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesModelsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Entities.Model[]> GetModelsAsync(ModelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetModelsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Entities.Model[]>(await stream.ReadToEndAsync());
                }
            }

            return new Entities.Model[0];
        }

        public async Task<Entities.Model[]> GetModelsOfMarksAsync(ModelsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetModelsOfMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Entities.Model[]>(await stream.ReadToEndAsync());
                }
            }

            return new Entities.Model[0];
        }

        public async Task<PopularityModels[]> GetPopularityModelsOfMarkAsync(Guid markId)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPopularityModelsOfMarkResponseAsync(markId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PopularityModels[]>(await stream.ReadToEndAsync());
                }
            }

            return new PopularityModels[0];
        }
    }
}
