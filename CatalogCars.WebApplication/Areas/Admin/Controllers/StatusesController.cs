using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatusesController : Controller
    {
        private readonly StatusesRequester _statusesRequester;

        public StatusesController()
        {
            _statusesRequester = new StatusesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(StatusesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _statusesRequester.GetCountStatusesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Statuses")]
        public async Task<IActionResult> Index()
        {
            var filters = new StatusesFilters();

            var viewModel = new StatusesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Statuses = (await _statusesRequester.GetStatusesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Statuses")]
        public async Task<PartialViewResult> Index([FromForm] StatusesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Statuses = (await _statusesRequester.GetStatusesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Statuses/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] StatusesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Statuses = (await _statusesRequester.GetStatusesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Statuses/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _statusesRequester.GetNamesStatusesAsync(searchString))
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
