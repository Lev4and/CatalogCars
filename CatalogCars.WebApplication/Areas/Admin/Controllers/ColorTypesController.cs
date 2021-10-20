using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorTypesController : Controller
    {
        private readonly ColorTypesRequester _colorTypesRequester;

        public ColorTypesController()
        {
            _colorTypesRequester = new ColorTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(ColorTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _colorTypesRequester.GetCountColorTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/ColorTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new ColorTypesFilters();

            var viewModel = new ColorTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                ColorTypes = (await _colorTypesRequester.GetColorTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/ColorTypes")]
        public async Task<PartialViewResult> Index([FromForm] ColorTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.ColorTypes = (await _colorTypesRequester.GetColorTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/ColorTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] ColorTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.ColorTypes = (await _colorTypesRequester.GetColorTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/ColorTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _colorTypesRequester.GetNamesColorTypesAsync(searchString))
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
