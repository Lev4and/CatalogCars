﻿using CatalogCars.Model.Database.AuxiliaryTypes;
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

        public async Task<HeadersAjaxRequestForCars> GetHeadersAjaxRequestForCars(RangeMileage rangeMileage, RangePrice rangePrice, int numberPage)
        {
            var result = new HeadersAjaxRequestForCars();
            var cookies = await _cookieLoader.GetCookies(rangeMileage, rangePrice, numberPage);

            result.CsrfToken = cookies.FirstOrDefault(cookie => cookie.Name == "_csrf_token").Value;

            foreach(var cookie in cookies)
            {
                result.CookieContent += $"{cookie.Name}={cookie.Value};";
            }

            result.CookieContent += "gradius=1000;gids=";

            return result;
        }
    }
}
