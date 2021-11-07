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
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Currency currency)
        {
            if (currency.Id == default)
            {
                if (_dataManager.Currencies.SaveCurrency(currency))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = currency.Id,
                        Status = SaveResultStatus.Success,
                        Message = "Успешное добавление новой записи"
                    });
                }
                else
                {
                    return BadRequest(new SaveResult<object>()
                    {
                        Result = null,
                        Status = SaveResultStatus.Failure,
                        Message = "Запись с такими данными уже существует"
                    });
                }
            }

            return BadRequest(new SaveResult<object>()
            {
                Result = null,
                Status = SaveResultStatus.Failure,
                Message = "Идентификатор должен иметь значение по умолчанию"
            });
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Update([FromBody] Currency currency)
        {
            if (currency.Id != default)
            {
                if (_dataManager.Currencies.SaveCurrency(currency))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = currency.Id,
                        Status = SaveResultStatus.Success,
                        Message = "Успешное добавление новой записи"
                    });
                }
                else
                {
                    return BadRequest(new SaveResult<object>()
                    {
                        Result = null,
                        Status = SaveResultStatus.Failure,
                        Message = "Запись с такими данными уже существует"
                    });
                }
            }

            return BadRequest(new SaveResult<object>()
            {
                Result = null,
                Status = SaveResultStatus.Failure,
                Message = "Идентификатор не должен иметь значение по умолчанию"
            });
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
