using CatalogCars.Resource.Requests;
using CatalogCars.Resource.Requests.HttpRequesters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Components
{
    public class Brands : ViewComponent
    {
        private readonly HttpClientContext _httpClientContext;

        public Brands()
        {
            _httpClientContext = new HttpClientContext();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", (await _httpClientContext.Marks.GetPopularMarksAsync()).ToList());
        }
    }
}
