using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/sellerTypes")]
    [Produces("application/json")]
    public class SellerTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SellerTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SellerTypesFilters filters)
        {
            return Ok(_dataManager.SellerTypes.GetCountSellerTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.SellerTypes.GetNamesSellerTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(SellerType[]), 200)]
        public IActionResult Index([FromBody] SellerTypesFilters filters)
        {
            return Ok(_dataManager.SellerTypes.GetSellerTypes(filters).ToArray());
        }
    }
}
