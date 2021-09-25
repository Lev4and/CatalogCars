using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    [Produces("application/json")]
    public class CurrenciesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public CurrenciesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] CurrenciesFilters filters)
        {
            return Ok(_dataManager.Currencies.GetCountCurrencies(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Currencies.GetNamesCurrencies(searchString).ToArray());
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Currency[]), 200)]
        public IActionResult Index([FromBody] CurrenciesFilters filters)
        {
            return Ok(_dataManager.Currencies.GetCurrencies(filters).ToArray());
        }
    }
}
