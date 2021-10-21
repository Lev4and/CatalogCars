using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CurrenciesController : Controller
    {
        private readonly CurrenciesRequester _currenciesRequester;

        public CurrenciesController()
        {
            _currenciesRequester = new CurrenciesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(CurrenciesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _currenciesRequester.GetCountCurrenciesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Currencies")]
        public async Task<IActionResult> Index()
        {
            var filters = new CurrenciesFilters();

            var viewModel = new CurrenciesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Currencies = (await _currenciesRequester.GetCurrenciesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Currencies")]
        public async Task<PartialViewResult> Index([FromForm] CurrenciesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Currencies = (await _currenciesRequester.GetCurrenciesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Currencies/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] CurrenciesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Currencies = (await _currenciesRequester.GetCurrenciesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Currencies/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _currenciesRequester.GetNamesCurrenciesAsync(searchString))
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
