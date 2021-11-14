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
    public class AvailabilitiesController : Controller
    {
        private readonly AvailabilitiesRequester _availabilitiesRequester;

        public AvailabilitiesController()
        {
            _availabilitiesRequester = new AvailabilitiesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(AvailabilitiesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _availabilitiesRequester.GetCountAvailabilitiesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new AvailabilitiesFilters();

            var viewModel = new AvailabilitiesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] AvailabilitiesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Availabilities = (await _availabilitiesRequester.GetAvailabilitiesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _availabilitiesRequester.GetNamesAvailabilitiesAsync(searchString))
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
            return View("Edit", new Availability());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _availabilitiesRequester.GetAvailabilityAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] Availability viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if(viewModel.Id == default)
                {
                    saveResult = await _availabilitiesRequester.AddAvailabilityAsync(viewModel);
                }
                else
                {
                    saveResult = await _availabilitiesRequester.UpdateAvailabilityAsync(viewModel);
                }

                if(saveResult.Status == SaveResultStatus.Success)
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
            await _availabilitiesRequester.DeleteAvailabilityAsync(id);

            return RedirectToAction("Index");
        }
    }
}
