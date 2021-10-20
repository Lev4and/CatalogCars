using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AvailabilitiesController : Controller
    {
        private readonly AvailabilitiesRequester _availabilitiesRequester;

        public AvailabilitiesController()
        {
            _availabilitiesRequester = new AvailabilitiesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(AvailabilitiesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _availabilitiesRequester.GetCountAvailabilitiesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Availabilities")]
        public async Task<IActionResult> Index()
        {
            var filters = new AvailabilitiesFilters();

            var viewModel = new AvailabilitiesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Availabilities")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Availabilities/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Availabilities/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _availabilitiesRequester.GetNamesAvailabilitiesAsync(searchString))
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
