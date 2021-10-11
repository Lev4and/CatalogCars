using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/prices")]
    [Produces("application/json")]
    public class PricesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PricesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("minPrice")]
        [ProducesResponseType(typeof(double), 200)]
        public IActionResult MinPrice([FromBody] Guid currencyId)
        {
            return Ok(_dataManager.Prices.GetMinPrice(currencyId));
        }

        [HttpPost("maxPrice")]
        [ProducesResponseType(typeof(double), 200)]
        public IActionResult MaxPrice([FromBody] Guid currencyId)
        {
            return Ok(_dataManager.Prices.GetMaxPrice(currencyId));
        }
    }
}
