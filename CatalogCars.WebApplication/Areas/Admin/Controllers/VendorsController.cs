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
    public class VendorsController : Controller
    {
        private readonly VendorsRequester _vendorsRequester;

        public VendorsController()
        {
            _vendorsRequester = new VendorsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(VendorsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _vendorsRequester.GetCountVendorsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Vendors")]
        public async Task<IActionResult> Index()
        {
            var filters = new VendorsFilters();

            var viewModel = new VendorsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Vendors = (await _vendorsRequester.GetVendorsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Vendors")]
        public async Task<PartialViewResult> Index([FromForm] VendorsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Vendors = (await _vendorsRequester.GetVendorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Vendors/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] VendorsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Vendors = (await _vendorsRequester.GetVendorsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Vendors/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _vendorsRequester.GetNamesVendorsAsync(searchString))
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
