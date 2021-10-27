using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenerationsController : Controller
    {
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;
        private readonly GenerationsRequester _generationsRequester;
        private readonly PriceSegmentsRequester _priceSegmentsRequester;

        public GenerationsController()
        {
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
            _generationsRequester = new GenerationsRequester();
            _priceSegmentsRequester = new PriceSegmentsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(GenerationsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _generationsRequester.GetCountGenerationsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Generations")]
        public async Task<IActionResult> Index()
        {
            var filters = new GenerationsFilters() 
            {
                RangeYearFrom = new RangeYearFrom(await _generationsRequester.GetMaxYearFromGenerationAsync(), 
                    await _generationsRequester.GetMinYearFromGenerationAsync())
            };

            var viewModel = new GenerationsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Marks = (await _marksRequester.GetMarksAsync()).ToList(),
                Generations = (await _generationsRequester.GetGenerationsAsync(filters)).ToList(),
                PriceSegments = (await _priceSegmentsRequester.GetPriceSegmentsAsync()).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Generations")]
        public async Task<PartialViewResult> Index([FromForm] GenerationsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Generations = (await _generationsRequester.GetGenerationsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Generations/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] GenerationsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Generations = (await _generationsRequester.GetGenerationsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Generations/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _generationsRequester.GetNamesGenerationsAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Generations/Models")]
        public async Task<JsonResult> Models([FromForm] Guid[] marksIds)
        {
            return Json(await _modelsRequester.GetModelsOfMarksAsync(marksIds));
        }
    }
}
