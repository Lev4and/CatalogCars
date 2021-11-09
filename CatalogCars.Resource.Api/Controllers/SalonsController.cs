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
    [Route("api/salons")]
    [Produces("application/json")]
    public class SalonsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SalonsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SalonsFilters filters)
        {
            return Ok(_dataManager.Salons.GetCountSalons(filters));
        }

        [HttpPost("minRegistrationDate")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinRegistrationDate()
        {
            return Ok(_dataManager.Salons.GetMinRegistrationDate());
        }

        [HttpPost("maxRegistrationDate")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxRegistrationDate()
        {
            return Ok(_dataManager.Salons.GetMaxRegistrationDate());
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Salons.GetNamesSalons(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Salon[]), 200)]
        public IActionResult Index([FromBody] SalonsFilters filters)
        {
            return Ok(_dataManager.Salons.GetSalons(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid locationId, [FromQuery][Required] string name)
        {
            return Ok(_dataManager.Salons.ContainsSalon(locationId, name));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Salon), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Salons.GetSalon(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Salon salon)
        {
            if (salon.Id == default)
            {
                if (_dataManager.Salons.SaveSalon(salon))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = salon.Id,
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
        public IActionResult Update([FromBody] Salon salon)
        {
            if (salon.Id != default)
            {
                if (_dataManager.Salons.SaveSalon(salon))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = salon.Id,
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
            _dataManager.Salons.DeleteSalon(id);

            return Ok();
        }
    }
}
