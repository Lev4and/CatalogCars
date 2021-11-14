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
    public class ColorsController : Controller
    {
        private readonly ColorsRequester _colorsRequester;

        public ColorsController()
        {
            _colorsRequester = new ColorsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(ColorsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _colorsRequester.GetCountColorsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Colors")]
        public async Task<IActionResult> Index()
        {
            var filters = new ColorsFilters();

            var viewModel = new ColorsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Colors = (await _colorsRequester.GetColorsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors")]
        public async Task<PartialViewResult> Index([FromForm] ColorsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Colors = (await _colorsRequester.GetColorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] ColorsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;

            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Colors = (await _colorsRequester.GetColorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Colors/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _colorsRequester.GetNamesColorsAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpGet]
        [Route("~/Admin/Colors/Add")]
        public IActionResult Add()
        {
            return View("Edit", new Color());
        }


        [Route("~/Admin/Colors/{id}/Edit")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return View("Edit", await _colorsRequester.GetColorAsync(id));
        }

        [HttpPost]
        [Route("~/Admin/Colors/Save")]
        public async Task<IActionResult> Save([FromForm] Color viewModel)
        {
            if (ModelState.IsValid)
            {
                var saveResult = new SaveResult<object>();

                if (viewModel.Id == default)
                {
                    saveResult = await _colorsRequester.AddColorAsync(viewModel);
                }
                else
                {
                    saveResult = await _colorsRequester.UpdateColorAsync(viewModel);
                }

                if (saveResult.Status == SaveResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Value", saveResult.Message);
            }

            return View("Edit", viewModel);
        }

        [HttpGet]
        [Route("~/Admin/Colors/{id}/Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _colorsRequester.DeleteColorAsync(id);

            return RedirectToAction("Index");
        }
    }
}
