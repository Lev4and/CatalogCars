using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OptionsController : Controller
    {
        private readonly OptionsRequester _optionsRequester;

        public OptionsController()
        {
            _optionsRequester = new OptionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(OptionsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _optionsRequester.GetCountOptionsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Options")]
        public async Task<IActionResult> Index()
        {
            var filters = new OptionsFilters();

            var viewModel = new OptionsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Options = (await _optionsRequester.GetOptionsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Options")]
        public async Task<PartialViewResult> Index([FromForm] OptionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Options = (await _optionsRequester.GetOptionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Options/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] OptionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Options = (await _optionsRequester.GetOptionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Options/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _optionsRequester.GetNamesOptionsAsync(searchString))
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
