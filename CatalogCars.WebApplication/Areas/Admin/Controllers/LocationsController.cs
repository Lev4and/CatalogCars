using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationsController : Controller
    {
        private readonly RegionsRequester _regionsRequester;
        private readonly LocationsRequester _locationsRequester;

        public LocationsController()
        {
            _regionsRequester = new RegionsRequester();
            _locationsRequester = new LocationsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(LocationsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _locationsRequester.GetCountLocationsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Locations")]
        public async Task<IActionResult> Index()
        {
            var filters = new LocationsFilters();

            var viewModel = new LocationsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Locations = (await _locationsRequester.GetLocationsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Locations")]
        public async Task<PartialViewResult> Index([FromForm] LocationsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Locations = (await _locationsRequester.GetLocationsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Locations/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] LocationsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Locations = (await _locationsRequester.GetLocationsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Locations/Addresses")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _locationsRequester.GetNamesLocationsAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Locations/Regions/Names")]
        public async Task<JsonResult> RegionsNames([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _regionsRequester.GetRegionsAsync(new RegionsFilters()
                {
                    ItemsPerPage = 5,
                    SearchString = searchString
                }))
                    .Select(region => new
                    {
                        Id = region.Id,
                        Text = region.Name
                    })
            });
        }
    }
}
