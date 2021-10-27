using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalonsController : Controller
    {
        private readonly SalonsRequester _salonsRequester;
        private readonly RegionsRequester _regionsRequester;

        public SalonsController()
        {
            _salonsRequester = new SalonsRequester();
            _regionsRequester = new RegionsRequester();
        }

        private async Task<Pagination> GetPaginationAsync(SalonsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _salonsRequester.GetCountSalonsAsync(filters)
            };
        }

        [HttpGet]
        [Route("~/Admin/Salons")]
        public async Task<IActionResult> Index()
        {
            var filters = new SalonsFilters(await _salonsRequester.GetMaxRegistrationDateSalonAsync(), 
                await _salonsRequester.GetMinRegistrationDateSalonAsync());

            var viewModel = new SalonsViewModel()
            {
                Filters = filters,
                Pagination = await GetPaginationAsync(filters),
                Salons = (await _salonsRequester.GetSalonsAsync(filters)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Salons")]
        public async Task<PartialViewResult> Index([FromForm] SalonsViewModel viewModel)
        {
            viewModel.Filters.NumberPage = 1;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Salons = (await _salonsRequester.GetSalonsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Salons/page={page}")]
        public async Task<PartialViewResult> Index([FromForm] SalonsViewModel viewModel, [FromRoute] int page)
        {
            viewModel.Filters.NumberPage = page;
            viewModel.Pagination = await GetPaginationAsync(viewModel.Filters);
            viewModel.Salons = (await _salonsRequester.GetSalonsAsync(viewModel.Filters)).ToList();

            return PartialView("_Table", viewModel);
        }

        [HttpPost]
        [Route("~/Admin/Salons/Names")]
        public async Task<JsonResult> Names([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _salonsRequester.GetNamesSalonsAsync(searchString))
                    .Append(searchString ?? "")
                    .Select(name => new
                    {
                        Id = name,
                        Text = name
                    })
            });
        }

        [HttpPost]
        [Route("~/Admin/Salons/Regions/Names")]
        public async Task<JsonResult> RegionsNames([FromForm] string searchString)
        {
            return Json(new
            {
                results = (await _regionsRequester.GetRegionsAsync(new RegionsFilters()
                {
                    ItemsPerPage = 5,
                    SearchString = searchString
                }))
                    .Select(region => new
                    {
                        Id = region.Id,
                        Text = region.Name
                    })
            });
        }
    }
}
