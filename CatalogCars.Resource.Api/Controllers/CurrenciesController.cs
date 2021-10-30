using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet]
        [ProducesResponseType(typeof(Currency[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Currencies.GetCurrencies().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Currency[]), 200)]
        public IActionResult Index([FromBody] CurrenciesFilters filters)
        {
            return Ok(_dataManager.Currencies.GetCurrencies(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name)
        {
            return Ok(_dataManager.Currencies.ContainsCurrency(name));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Currency), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Currencies.GetCurrency(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Add([FromBody] Currency currency)
        {
            if (currency.Id == default)
            {
                return Ok(_dataManager.Currencies.SaveCurrency(currency));
            }

            return BadRequest(false);
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Update([FromBody] Currency currency)
        {
            if (currency.Id != default)
            {
                return Ok(_dataManager.Currencies.SaveCurrency(currency));
            }

            return BadRequest(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.Currencies.DeleteCurrency(id);

            return Ok();
        }
    }
}
