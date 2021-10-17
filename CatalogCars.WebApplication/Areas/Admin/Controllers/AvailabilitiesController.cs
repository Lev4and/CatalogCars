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

        [HttpGet]
        [Route("~/Admin/Availabilities")]
        public async Task<IActionResult> Index()
        {
            var filters = new AvailabilitiesFilters();

            var pagination = new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _availabilitiesRequester.GetCountAvailabilitiesAsync(filters)
            };

            var viewModel = new AvailabilitiesViewModel()
            {
                Filters = filters,
                Pagination = pagination,
                Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Availabilities")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination.NumberPage = viewModel.Filters.NumberPage;
            viewModel.Pagination.ItemsPerPage = viewModel.Filters.ItemsPerPage;
            viewModel.Pagination.CountTotalItems = await _availabilitiesRequester.GetCountAvailabilitiesAsync(viewModel.Filters);

            viewModel.Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Availabilities/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination.NumberPage = viewModel.Filters.NumberPage;
            viewModel.Pagination.ItemsPerPage = viewModel.Filters.ItemsPerPage;
            viewModel.Pagination.CountTotalItems = await _availabilitiesRequester.GetCountAvailabilitiesAsync(viewModel.Filters);

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
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Availabilities/ResetFilters")]
        public PartialViewResult ResetFilters()
        {
            return PartialView("_Form", new AvailabilitiesViewModel() { Filters = new AvailabilitiesFilters() });
        }
    }
}
