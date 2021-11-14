using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("~/[area]/[controller]")]
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
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypeGroupsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypeGroupsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _bodyTypeGroupsRequester.GetNamesBodyTypeGroupsAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                        {
                            Id = name,
                            Text = name
                        })
            });
        }

        [HttpGet]
        [Route("~/[area]/[controller]/[action]")]
        public IActionResult Add()
        {
            return View("Edit", new BodyTypeGroup());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _bodyTypeGroupsRequester.GetBodyTypeGroupAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] BodyTypeGroup viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _bodyTypeGroupsRequester.AddBodyTypeGroupAsync(viewModel);
                }
                else
                {
                    saveResult = await _bodyTypeGroupsRequester.UpdateBodyTypeGroupAsync(viewModel);
                }

                if (saveResult.Status == SaveResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Name", saveResult.Message);
                ModelState.AddModelError("RuName", saveResult.Message);
                ModelState.AddModelError("AutoClass", saveResult.Message);
            }

            return View("Edit", viewModel);
        }

        [HttpGet]
        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _bodyTypeGroupsRequester.DeleteBodyTypeGroupAsync(id);

            return RedirectToAction("Index");
        }
    }
}
