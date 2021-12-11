using CatalogCars.WebApplication.Models;
using CatalogCars.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogViewModelGenerator _catalogViewModelGenerator;

        public CatalogController()
        {
            _catalogViewModelGenerator = new CatalogViewModelGenerator();
        }

        [Route("~/[controller]")]
        public async Task<IActionResult> Index()
        {
            return View(await _catalogViewModelGenerator.GenerateAsync());
        }

        [HttpPost]
        [Route("~/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] CatalogViewModel viewModel)
        {
            return PartialView("_ListView", await _catalogViewModelGenerator.GenerateAsync(viewModel.Filters));
        }
    }
}
