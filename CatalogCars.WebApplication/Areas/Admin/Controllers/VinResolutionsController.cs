using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VinResolutionsController : Controller
    {
        private readonly VinResolutionsRequester _vinResolutionsRequester;

        public VinResolutionsController()
        {
            _vinResolutionsRequester = new VinResolutionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(VinResolutionsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _vinResolutionsRequester.GetCountVinResolutionsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/VinResolutions")]
        public async Task<IActionResult> Index()
        {
            var filters = new VinResolutionsFilters();

            var viewModel = new VinResolutionsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                VinResolutions = (await _vinResolutionsRequester.GetVinResolutionsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/VinResolutions")]
        public async Task<PartialViewResult> Index([FromForm] VinResolutionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.VinResolutions = (await _vinResolutionsRequester.GetVinResolutionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/VinResolutions/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] VinResolutionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.VinResolutions = (await _vinResolutionsRequester.GetVinResolutionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/VinResolutions/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _vinResolutionsRequester.GetNamesVinResolutionsAsync(searchString))
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
