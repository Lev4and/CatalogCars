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
    public class PtsTypesController : Controller
    {
        private readonly PtsTypesRequester _ptsTypesRequester;

        public PtsTypesController()
        {
            _ptsTypesRequester = new PtsTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(PtsTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _ptsTypesRequester.GetCountPtsTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new PtsTypesFilters();

            var viewModel = new PtsTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] PtsTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] PtsTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.PtsTypes = (await _ptsTypesRequester.GetPtsTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _ptsTypesRequester.GetNamesPtsTypesAsync(searchString))
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
            return View("Edit", new PtsType());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _ptsTypesRequester.GetPtsTypeAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] PtsType viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _ptsTypesRequester.AddPtsTypeAsync(viewModel);
                }
                else
                {
                    saveResult = await _ptsTypesRequester.UpdatePtsTypeAsync(viewModel);
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
            await _ptsTypesRequester.DeletePtsTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
