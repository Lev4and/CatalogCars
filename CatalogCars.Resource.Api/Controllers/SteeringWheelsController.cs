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
    [Route("api/steeringWheels")]
    [Produces("application/json")]
    public class SteeringWheelsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SteeringWheelsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SteeringWheelsFilters filters)
        {
            return Ok(_dataManager.SteeringWheels.GetCountSteeringWheels(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.SteeringWheels.GetNamesSteeringWheels(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(SteeringWheel[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.SteeringWheels.GetSteeringWheels().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(SteeringWheel[]), 200)]
        public IActionResult Index([FromBody] SteeringWheelsFilters filters)
        {
            return Ok(_dataManager.SteeringWheels.GetSteeringWheels(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.SteeringWheels.ContainsSteeringWheel(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SteeringWheel), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.SteeringWheels.GetSteeringWheel(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] SteeringWheel steeringWheel)
        {
            if (steeringWheel.Id == default)
            {
                if (_dataManager.SteeringWheels.SaveSteeringWheel(steeringWheel))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = steeringWheel.Id,
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

        [HttpPut("update")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Update([FromBody] SteeringWheel steeringWheel)
        {
            if (steeringWheel.Id != default)
            {
                if (_dataManager.SteeringWheels.SaveSteeringWheel(steeringWheel))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = steeringWheel.Id,
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

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery][Required] Guid id)
        {
            _dataManager.SteeringWheels.DeleteSteeringWheel(id);

            return Ok();
        }
    }
}
