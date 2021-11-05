using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieLoaders;
using CatalogCars.Model.Parsers.AutoRu.Types;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.CookieWorkers
{
    public class CarsCookieWorker
    {
        private readonly CarsCookieLoader _cookieLoader;

        public CarsCookieWorker()
        {
            _cookieLoader = new CarsCookieLoader();
        }

        public async Task<HeadersAjaxRequestForCars> GetHeadersAjaxRequestForCars()
        {
            var result = new HeadersAjaxRequestForCars();
            var cookies = await _cookieLoader.GetCookies();

            result.CsrfToken = cookies.FirstOrDefault(cookie => cookie.Name == "_csrf_token").Value;

            foreach (var cookie in cookies)
            {
                result.CookieContent += $"{cookie.Name}={cookie.Value};";
            }

            result.CookieContent += "gradius=1000;gids=";

            return result;
        }

        public async Task<HeadersAjaxRequestForCars> GetHeadersAjaxRequestForCars(RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            try
            {
                var result = new HeadersAjaxRequestForCars();
                var cookies = await _cookieLoader.GetCookies(rangeMileage, rangePrice, pageSize, topDays, numberPage);

                result.CsrfToken = cookies.FirstOrDefault(cookie => cookie.Name == "_csrf_token").Value;

                foreach (var cookie in cookies)
                {
                    result.CookieContent += $"{cookie.Name}={cookie.Value};";
                }

                result.CookieContent += "gradius=1000;gids=";

                return result;
            }
            catch
            {
                return new HeadersAjaxRequestForCars();
            }
        }
    }
}
