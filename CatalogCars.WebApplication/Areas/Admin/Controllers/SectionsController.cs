using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionsController : Controller
    {
        private readonly SectionsRequester _sectionsRequester;

        public SectionsController()
        {
            _sectionsRequester = new SectionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SectionsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _sectionsRequester.GetCountSectionsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Sections")]
        public async Task<IActionResult> Index()
        {
            var filters = new SectionsFilters();

            var viewModel = new SectionsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Sections = (await _sectionsRequester.GetSectionsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sections")]
        public async Task<PartialViewResult> Index([FromForm] SectionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Sections = (await _sectionsRequester.GetSectionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sections/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SectionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Sections = (await _sectionsRequester.GetSectionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Sections/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _sectionsRequester.GetNamesSectionsAsync(searchString))
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
