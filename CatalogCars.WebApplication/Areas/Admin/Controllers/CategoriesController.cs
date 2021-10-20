using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        private async Task<Pagination> GetPaginationAsync(CategoriesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _categoriesRequester.GetCountCategoriesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Categories")]
        public async Task<IActionResult> Index()
        {
            var filters = new CategoriesFilters();

            var viewModel = new CategoriesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Categories = (await _categoriesRequester.GetCategoriesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Categories")]
        public async Task<PartialViewResult> Index([FromForm] CategoriesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Categories = (await _categoriesRequester.GetCategoriesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Categories/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] CategoriesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Categories = (await _categoriesRequester.GetCategoriesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Categories/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _categoriesRequester.GetNamesCategoriesAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }
    }
}
