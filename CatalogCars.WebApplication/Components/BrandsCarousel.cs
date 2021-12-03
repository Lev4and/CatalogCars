using CatalogCars.Resource.Requests.HttpRequesters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Components
{
    public class BrandsCarousel : ViewComponent
    {
        private readonly MarksRequester _marksRequester;

        public BrandsCarousel()
        {
            _marksRequester = new MarksRequester();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", (await _marksRequester.GetPopularMarksAsync()).ToList());
        }
    }
}
