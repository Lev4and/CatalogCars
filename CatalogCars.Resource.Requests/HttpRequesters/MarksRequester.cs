using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class MarksRequester
    {
        private readonly MarksResponseLoader _responseLoader;

        public MarksRequester()
        {
            _responseLoader = new MarksResponseLoader();
        }

        public async Task<int> GetCountMarksAsync(MarksFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesMarksAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesMarksResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Mark[]> GetMarksAsync(MarksFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetMarksResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Mark[]>(await stream.ReadToEndAsync());
                }
            }

            return new Mark[0];
        }
    }
}
