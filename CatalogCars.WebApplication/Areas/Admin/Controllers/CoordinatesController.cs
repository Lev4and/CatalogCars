using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoordinatesController : Controller
    {
        private readonly RegionsRequester _regionsRequester;
        private readonly CoordinatesRequester _coordinatesRequester;

        public CoordinatesController()
        {
            _regionsRequester = new RegionsRequester();
            _coordinatesRequester = new CoordinatesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(CoordinatesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _coordinatesRequester.GetCountCoordinatesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Coordinates")]
        public async Task<IActionResult> Index()
        {
            var filters = new CoordinatesFilters();

            var viewModel = new CoordinatesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Coordinates = (await _coordinatesRequester.GetCoordinatesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Coordinates")]
        public async Task<PartialViewResult> Index([FromForm] CoordinatesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Coordinates = (await _coordinatesRequester.GetCoordinatesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Coordinates/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] CoordinatesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Coordinates = (await _coordinatesRequester.GetCoordinatesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Coordinates/Addresses")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _coordinatesRequester.GetNamesCoordinatesAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Coordinates/Regions/Names")]
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
