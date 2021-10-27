using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriceSegmentsController : Controller
    {
        private readonly PriceSegmentsRequester _priceSegmentsRequester;

        public PriceSegmentsController()
        {
            _priceSegmentsRequester = new PriceSegmentsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(PriceSegmentsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _priceSegmentsRequester.GetCountPriceSegmentsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/PriceSegments")]
        public async Task<IActionResult> Index()
        {
            var filters = new PriceSegmentsFilters();

            var viewModel = new PriceSegmentsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                PriceSegments = (await _priceSegmentsRequester.GetPriceSegmentsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PriceSegments")]
        public async Task<PartialViewResult> Index([FromForm] PriceSegmentsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PriceSegments = (await _priceSegmentsRequester.GetPriceSegmentsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PriceSegments/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] PriceSegmentsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PriceSegments = (await _priceSegmentsRequester.GetPriceSegmentsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PriceSegments/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _priceSegmentsRequester.GetNamesPriceSegmentsAsync(searchString))
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
