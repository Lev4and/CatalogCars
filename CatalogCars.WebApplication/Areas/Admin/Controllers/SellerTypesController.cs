using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerTypesController : Controller
    {
        private readonly SellerTypesRequester _sellerTypesRequester;

        public SellerTypesController()
        {
            _sellerTypesRequester = new SellerTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SellerTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _sellerTypesRequester.GetCountSellerTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/SellerTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new SellerTypesFilters();

            var viewModel = new SellerTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SellerTypes")]
        public async Task<PartialViewResult> Index([FromForm] SellerTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SellerTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SellerTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SellerTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _sellerTypesRequester.GetNamesSellerTypesAsync(searchString))
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
