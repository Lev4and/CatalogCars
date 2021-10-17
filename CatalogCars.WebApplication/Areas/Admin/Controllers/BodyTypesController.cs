using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodyTypesController : Controller
    {
        private readonly BodyTypesRequester _bodyTypesRequester;
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;

        public BodyTypesController()
        {
            _bodyTypesRequester = new BodyTypesRequester();
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
        }

        [HttpGet]
        [Route("~/Admin/BodyTypes")]
        public async Task<IActionResult> Index()
        {
            var filters = new BodyTypesFilters();

            var pagination = new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _bodyTypesRequester.GetCountBodyTypesAsync(filters)
            };

            var viewModel = new BodyTypesViewModel()
            {
                Filters = filters,
                Pagination = pagination,
                BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(filters)).ToList(),
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync()).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypes")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination.NumberPage = viewModel.Filters.NumberPage;
            viewModel.Pagination.ItemsPerPage = viewModel.Filters.ItemsPerPage;
            viewModel.Pagination.CountTotalItems = await _bodyTypesRequester.GetCountBodyTypesAsync(viewModel.Filters);

            viewModel.BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypes/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination.NumberPage = viewModel.Filters.NumberPage;
            viewModel.Pagination.ItemsPerPage = viewModel.Filters.ItemsPerPage;
            viewModel.Pagination.CountTotalItems = await _bodyTypesRequester.GetCountBodyTypesAsync(viewModel.Filters);

            viewModel.BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypes/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _bodyTypesRequester.GetNamesBodyTypesAsync(searchString))
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/BodyTypes/ResetFilters")]
        public async Task<PartialViewResult> ResetFilters()
        {
            return PartialView("_Form", new BodyTypesViewModel() 
            { 
                Filters = new BodyTypesFilters(),
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync()).ToList()
            });
        }
    }
}
