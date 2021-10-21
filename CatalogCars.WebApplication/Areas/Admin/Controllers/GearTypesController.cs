using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GearTypesController : Controller
    {
        private readonly GearTypesRequester _gearTypesRequester;

        public GearTypesController()
        {
            _gearTypesRequester = new GearTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(GearTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _gearTypesRequester.GetCountGearTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/GearTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new GearTypesFilters();

            var viewModel = new GearTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                GearTypes = (await _gearTypesRequester.GetGearTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/GearTypes")]
        public async Task<PartialViewResult> Index([FromForm] GearTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.GearTypes = (await _gearTypesRequester.GetGearTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/GearTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] GearTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.GearTypes = (await _gearTypesRequester.GetGearTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/GearTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _gearTypesRequester.GetNamesGearTypesAsync(searchString))
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
