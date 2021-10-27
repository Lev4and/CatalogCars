using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly TagsRequester _tagsRequester;

        public TagsController()
        {
            _tagsRequester = new TagsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(TagsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _tagsRequester.GetCountTagsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Tags")]
        public async Task<IActionResult> Index()
        {
            var filters = new TagsFilters();

            var viewModel = new TagsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Tags = (await _tagsRequester.GetTagsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Tags")]
        public async Task<PartialViewResult> Index([FromForm] TagsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Tags = (await _tagsRequester.GetTagsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Tags/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] TagsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Tags = (await _tagsRequester.GetTagsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Tags/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _tagsRequester.GetNamesTagsAsync(searchString))
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
