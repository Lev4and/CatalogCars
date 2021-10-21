using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarksController : Controller
    {
        private readonly MarksRequester _marksRequester;

        public MarksController()
        {
            _marksRequester = new MarksRequester();
        }

        private async Task<Pagination> GetPaginationAsync(MarksFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _marksRequester.GetCountMarksAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Marks")]
        public async Task<IActionResult> Index()
        {
            var filters = new MarksFilters();

            var viewModel = new MarksViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Marks = (await _marksRequester.GetMarksAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Marks")]
        public async Task<PartialViewResult> Index([FromForm] MarksViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Marks = (await _marksRequester.GetMarksAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Marks/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] MarksViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Marks = (await _marksRequester.GetMarksAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Marks/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _marksRequester.GetNamesMarksAsync(searchString))
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
