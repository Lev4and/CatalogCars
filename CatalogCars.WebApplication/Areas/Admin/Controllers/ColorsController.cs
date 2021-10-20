using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly ColorsRequester _colorsRequester;

        public ColorsController()
        {
            _colorsRequester = new ColorsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(ColorsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _colorsRequester.GetCountColorsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Colors")]
        public async Task<IActionResult> Index()
        {
            var filters = new ColorsFilters();

            var viewModel = new ColorsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Colors = (await _colorsRequester.GetColorsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors")]
        public async Task<PartialViewResult> Index([FromForm] ColorsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Colors = (await _colorsRequester.GetColorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] ColorsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Colors = (await _colorsRequester.GetColorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _colorsRequester.GetNamesColorsAsync(searchString))
                    .Append(searchString)
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }
    }
}
