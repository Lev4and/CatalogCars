using CatalogCars.Resource.Requests.HttpRequesters;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesRequester _categoriesRequester;

        public CategoriesController()
        {
            _categoriesRequester = new CategoriesRequester();
        }
    }
}
