using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PtsTypesController : Controller
    {
        private readonly PtsTypesRequester _ptsTypesRequester;

        public PtsTypesController()
        {
            _ptsTypesRequester = new PtsTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(PtsTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _ptsTypesRequester.GetCountPtsTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/PtsTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new PtsTypesFilters();

            var viewModel = new PtsTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PtsTypes")]
        public async Task<PartialViewResult> Index([FromForm] PtsTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PtsTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] PtsTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PtsTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _ptsTypesRequester.GetNamesPtsTypesAsync(searchString))
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
