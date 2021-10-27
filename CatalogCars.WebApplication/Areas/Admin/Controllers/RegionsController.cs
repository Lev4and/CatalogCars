using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegionsController : Controller
    {
        private readonly RegionsRequester _regionsRequester;

        public RegionsController()
        {
            _regionsRequester = new RegionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(RegionsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _regionsRequester.GetCountRegionsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Regions")]
        public async Task<IActionResult> Index()
        {
            var filters = new RegionsFilters();

            var viewModel = new RegionsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Regions = (await _regionsRequester.GetRegionsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Regions")]
        public async Task<PartialViewResult> Index([FromForm] RegionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Regions = (await _regionsRequester.GetRegionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Regions/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] RegionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Regions = (await _regionsRequester.GetRegionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Regions/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _regionsRequester.GetNamesRegionsAsync(searchString))
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
