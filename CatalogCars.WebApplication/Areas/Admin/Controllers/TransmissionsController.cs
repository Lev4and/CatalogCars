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
        [Route("~/Admin/Transmissions")]
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
        [Route("~/Admin/Transmissions")]
        public async Task<PartialViewResult> Index([FromForm] TransmissionsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Transmissions = (await _transmissionsRequester.GetTransmissionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Transmissions/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] TransmissionsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Transmissions = (await _transmissionsRequester.GetTransmissionsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Transmissions/Names")]
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
    }
}
