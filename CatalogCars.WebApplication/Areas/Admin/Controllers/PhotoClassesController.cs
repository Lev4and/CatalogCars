using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoClassesController : Controller
    {
        private readonly PhotoClassesRequester _photoClassesRequester;

        public PhotoClassesController()
        {
            _photoClassesRequester = new PhotoClassesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(PhotoClassesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _photoClassesRequester.GetCountPhotoClassesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/PhotoClasses")]
        public async Task<IActionResult> Index()
        {
            var filters = new PhotoClassesFilters();

            var viewModel = new PhotoClassesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                PhotoClasses = (await _photoClassesRequester.GetPhotoClassesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PhotoClasses")]
        public async Task<PartialViewResult> Index([FromForm] PhotoClassesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PhotoClasses = (await _photoClassesRequester.GetPhotoClassesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PhotoClasses/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] PhotoClassesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PhotoClasses = (await _photoClassesRequester.GetPhotoClassesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/PhotoClasses/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _photoClassesRequester.GetNamesPhotoClassesAsync(searchString))
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
