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
    [Route("api/availabilities")]
    [Produces("application/json")]
    public class AvailabilitiesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public AvailabilitiesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] AvailabilitiesFilters filters)
        {
            return Ok(_dataManager.Availabilities.GetCountAvailabilities(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Availabilities.GetNamesAvailabilities(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Availability[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Availabilities.GetAvailabilities().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Availability[]), 200)]
        public IActionResult Index([FromBody] AvailabilitiesFilters filters)
        {
            return Ok(_dataManager.Availabilities.GetAvailabilities(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Availabilities.ContainsAvailability(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Availability), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Availabilities.GetAvailability(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Availability availability)
        {
            if(availability.Id == default)
            {
                if(_dataManager.Availabilities.SaveAvailability(availability))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = availability.Id,
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
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Update([FromBody] Availability availability)
        {
            if(availability.Id != default)
            {
                if (_dataManager.Availabilities.SaveAvailability(availability))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = availability.Id,
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
            _dataManager.Availabilities.DeleteAvailability(id);

            return Ok();
        }
    }
}
