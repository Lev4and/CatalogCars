using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EngineTypesController : Controller
    {
        private readonly EngineTypesRequester _engineTypesRequester;

        public EngineTypesController()
        {
            _engineTypesRequester = new EngineTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(EngineTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _engineTypesRequester.GetCountEngineTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/EngineTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new EngineTypesFilters();

            var viewModel = new EngineTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                EngineTypes = (await _engineTypesRequester.GetEngineTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/EngineTypes")]
        public async Task<PartialViewResult> Index([FromForm] EngineTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.EngineTypes = (await _engineTypesRequester.GetEngineTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/EngineTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] EngineTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.EngineTypes = (await _engineTypesRequester.GetEngineTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/EngineTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _engineTypesRequester.GetNamesEngineTypesAsync(searchString))
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
