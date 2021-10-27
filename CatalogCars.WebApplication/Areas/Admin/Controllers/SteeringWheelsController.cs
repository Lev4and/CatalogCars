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
    public class SteeringWheelsController : Controller
    {
        private readonly SteeringWheelsRequester _steeringWheelsRequester;

        public SteeringWheelsController()
        {
            _steeringWheelsRequester = new SteeringWheelsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SteeringWheelsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _steeringWheelsRequester.GetCountSteeringWheelsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/SteeringWheels")]
        public async Task<IActionResult> Index()
        {
            var filters = new SteeringWheelsFilters();

            var viewModel = new SteeringWheelsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                SteeringWheels = (await _steeringWheelsRequester.GetSteeringWheelsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SteeringWheels")]
        public async Task<PartialViewResult> Index([FromForm] SteeringWheelsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SteeringWheels = (await _steeringWheelsRequester.GetSteeringWheelsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SteeringWheels/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SteeringWheelsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.SteeringWheels = (await _steeringWheelsRequester.GetSteeringWheelsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/SteeringWheels/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _steeringWheelsRequester.GetNamesSteeringWheelsAsync(searchString))
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
