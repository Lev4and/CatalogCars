using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhonesController : Controller
    {
        private readonly PhonesRequester _phonesRequester;

        public PhonesController()
        {
            _phonesRequester = new PhonesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(PhonesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _phonesRequester.GetCountPhonesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Phones")]
        public async Task<IActionResult> Index()
        {
            var filters = new PhonesFilters();

            var viewModel = new PhonesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Phones = (await _phonesRequester.GetPhonesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Phones")]
        public async Task<PartialViewResult> Index([FromForm] PhonesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Phones = (await _phonesRequester.GetPhonesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Phones/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] PhonesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Phones = (await _phonesRequester.GetPhonesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Phones/Values")]
        public async Task<JsonResult> Values([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _phonesRequester.GetNamesPhonesAsync(searchString))
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
