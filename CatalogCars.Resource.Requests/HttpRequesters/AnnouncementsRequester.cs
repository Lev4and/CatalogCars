using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class AnnouncementsRequester
    {
        private readonly AnnouncementsResponseLoader _responseLoader;

        public AnnouncementsRequester()
        {
            _responseLoader = new AnnouncementsResponseLoader();
        }

        public async Task<int> GetCountAnnouncementsAsync(AnnouncementsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountAnnouncementsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesAnnouncementsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesAnnouncementsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Announcement[]> GetAnnouncementsAsync(AnnouncementsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetAnnouncementsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Announcement[]>(await stream.ReadToEndAsync());
                }
            }

            return new Announcement[0];
        }
    }
}
