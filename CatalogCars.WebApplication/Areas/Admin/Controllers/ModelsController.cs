using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelsController : Controller
    {
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;

        public ModelsController()
        {
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(ModelsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _modelsRequester.GetCountModelsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Models")]
        public async Task<IActionResult> Index()
        {
            var filters = new ModelsFilters();

            var viewModel = new ModelsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Marks = (await _marksRequester.GetMarksAsync()).ToList(),
                Models = (await _modelsRequester.GetModelsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Models")]
        public async Task<PartialViewResult> Index([FromForm] ModelsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Models = (await _modelsRequester.GetModelsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Models/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] ModelsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Models = (await _modelsRequester.GetModelsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Models/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _modelsRequester.GetNamesModelsAsync(searchString))
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
