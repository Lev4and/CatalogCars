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
    public class SellerTypesController : Controller
    {
        private readonly SellerTypesRequester _sellerTypesRequester;

        public SellerTypesController()
        {
            _sellerTypesRequester = new SellerTypesRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SellerTypesFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _sellerTypesRequester.GetCountSellerTypesAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var filters = new SellerTypesFilters();

            var viewModel = new SellerTypesViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]")]
        public async Task<PartialViewResult> Index([FromForm] SellerTypesViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SellerTypesViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SellerTypes = (await _sellerTypesRequester.GetSellerTypesAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _sellerTypesRequester.GetNamesSellerTypesAsync(searchString))
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
            return View("Edit", new SellerType());
        }


        [Route("~/[area]/[controller]/{id}/[action]")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _sellerTypesRequester.GetSellerTypeAsync(id));
        }

        [HttpPost]
        [Route("~/[area]/[controller]/[action]")]
        public async Task<IActionResult> Save([FromForm] SellerType viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _sellerTypesRequester.AddSellerTypeAsync(viewModel);
                }
                else
                {
                    saveResult = await _sellerTypesRequester.UpdateSellerTypeAsync(viewModel);
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
            await _sellerTypesRequester.DeleteSellerTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
