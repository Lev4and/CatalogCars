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
    public class BodyTypesController : Controller
    {
        private readonly BodyTypesRequester _bodyTypesRequester;
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;

        public BodyTypesController()
        {
            _bodyTypesRequester = new BodyTypesRequester();
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(BodyTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _bodyTypesRequester.GetCountBodyTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new BodyTypesFilters();

            var viewModel = new BodyTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(filters)).ToList(),
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync()).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] BodyTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.BodyTypes = (await _bodyTypesRequester.GetBodyTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _bodyTypesRequester.GetNamesBodyTypesAsync(searchString))
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
        public async Task<IActionResult> Add()
        {
            return View("Edit", new BodyTypeViewModel() 
            { 
                BodyType = new BodyType(), 
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync()).ToList() 
            });
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", new BodyTypeViewModel()
            {
                BodyType = await _bodyTypesRequester.GetBodyTypeAsync(id),
                BodyTypeGroups = (await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync()).ToList()
            });
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] BodyTypeViewModel viewModel)
        {
            var saveResult = new SaveResult<object>();

            if (viewModel.BodyType.Id == default)
            {
                saveResult = await _bodyTypesRequester.AddBodyTypeAsync(viewModel.BodyType);
            }
            else
            {
                saveResult = await _bodyTypesRequester.UpdateBodyTypeAsync(viewModel.BodyType);
            }

            if (saveResult.Status == SaveResultStatus.Success)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("BodyType.Name", saveResult.Message);
            ModelState.AddModelError("BodyType.RuName", saveResult.Message);
            ModelState.AddModelError("BodyType.BodyTypeGroupId", saveResult.Message);

            return View("Edit", viewModel);
        }

        [HttpGet]
        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _bodyTypesRequester.DeleteBodyTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
