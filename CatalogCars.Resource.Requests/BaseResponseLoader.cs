using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests
{
    public class BaseResponseLoader
    {
        public BaseResponseLoader()
        {

        }

        protected async Task<Stream> GetStreamFromResponseAsync(HttpResponseMessage response)
        {
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStreamAsync();
                }
            }

            return null;
        }
    }
}
