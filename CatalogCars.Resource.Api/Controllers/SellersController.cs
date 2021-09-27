using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/sellers")]
    [Produces("application/json")]
    public class SellersController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SellersController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SellersFilters filters)
        {
            return Ok(_dataManager.Sellers.GetCountSellers(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Sellers.GetNamesSellers(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Seller[]), 200)]
        public IActionResult Index([FromBody] SellersFilters filters)
        {
            return Ok(_dataManager.Sellers.GetSellers(filters).ToArray());
        }
    }
}
