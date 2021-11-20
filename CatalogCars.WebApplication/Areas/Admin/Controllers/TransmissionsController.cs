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
    public class TransmissionsController : Controller
    {
        private readonly TransmissionsRequester _transmissionsRequester;

        public TransmissionsController()
        {
            _transmissionsRequester = new TransmissionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(TransmissionsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _transmissionsRequester.GetCountTransmissionsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new TransmissionsFilters();

            var viewModel = new TransmissionsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Transmissions = (await _transmissionsRequester.GetTransmissionsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] TransmissionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Transmissions = (await _transmissionsRequester.GetTransmissionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] TransmissionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Transmissions = (await _transmissionsRequester.GetTransmissionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _transmissionsRequester.GetNamesTransmissionsAsync(searchString))
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
            return View("Edit", new Transmission());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _transmissionsRequester.GetTransmissionAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] Transmission viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _transmissionsRequester.AddTransmissionAsync(viewModel);
                }
                else
                {
                    saveResult = await _transmissionsRequester.UpdateTransmissionAsync(viewModel);
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
            await _transmissionsRequester.DeleteTransmissionAsync(id);

            return RedirectToAction("Index");
        }
    }
}
