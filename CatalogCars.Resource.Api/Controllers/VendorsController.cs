using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/vendors")]
    [Produces("application/json")]
    public class VendorsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public VendorsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] VendorsFilters filters)
        {
            return Ok(_dataManager.Vendors.GetCountVendors(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Vendors.GetNamesVendors(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vendor[]), 200)]
        public IActionResult Index([FromBody] VendorsFilters filters)
        {
            return Ok(_dataManager.Vendors.GetVendors(filters).ToArray());
        }
    }
}
