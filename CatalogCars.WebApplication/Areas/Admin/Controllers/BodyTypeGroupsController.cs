using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodyTypeGroupsController : Controller
    {
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;

        public BodyTypeGroupsController()
        {
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(BodyTypeGroupsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _bodyTypeGroupsRequester.GetCountBodyTypeGroupsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/BodyTypeGroups")]
        public async Task<IActionResult> Index()
        {
            var filters = new BodyTypeGroupsFilters();

            var viewModel = new BodyTypeGroupsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypeGroups")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypeGroupsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypeGroups/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypeGroupsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/BodyTypeGroups/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _bodyTypeGroupsRequester.GetNamesBodyTypeGroupsAsync(searchString))
                    .Append(searchString)
                    .Select(name => new
                        {
                            Id = name,
                            Text = name
                        })
            });
        }
    }
}
