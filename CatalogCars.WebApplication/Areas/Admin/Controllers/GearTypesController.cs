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
    public class GearTypesController : Controller
    {
        private readonly GearTypesRequester _gearTypesRequester;

        public GearTypesController()
        {
            _gearTypesRequester = new GearTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(GearTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _gearTypesRequester.GetCountGearTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new GearTypesFilters();

            var viewModel = new GearTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                GearTypes = (await _gearTypesRequester.GetGearTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] GearTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.GearTypes = (await _gearTypesRequester.GetGearTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] GearTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.GearTypes = (await _gearTypesRequester.GetGearTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _gearTypesRequester.GetNamesGearTypesAsync(searchString))
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
            return View("Edit", new GearType());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _gearTypesRequester.GetGearTypeAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] GearType viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _gearTypesRequester.AddGearTypeAsync(viewModel);
                }
                else
                {
                    saveResult = await _gearTypesRequester.UpdateGearTypeAsync(viewModel);
                }

                if (saveResult.Status == SaveResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Name", saveResult.Message);
                ModelState.AddModelError("RuName", saveResult.Message);
            }

            return View("Edit", viewModel);
        }

        [HttpGet]
        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _gearTypesRequester.DeleteGearTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
