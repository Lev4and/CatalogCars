using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellersController : Controller
    {
        private readonly SellersRequester _sellersRequester;
        private readonly RegionsRequester _regionsRequester;

        public SellersController()
        {
            _sellersRequester = new SellersRequester();
            _regionsRequester = new RegionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SellersFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _sellersRequester.GetCountSellersAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Sellers")]
        public async Task<IActionResult> Index()
        {
            var filters = new SellersFilters();

            var viewModel = new SellersViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Sellers = (await _sellersRequester.GetSellersAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sellers")]
        public async Task<PartialViewResult> Index([FromForm] SellersViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Sellers = (await _sellersRequester.GetSellersAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sellers/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SellersViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Sellers = (await _sellersRequester.GetSellersAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sellers/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _sellersRequester.GetNamesSellersAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Sellers/Regions/Names")]
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
