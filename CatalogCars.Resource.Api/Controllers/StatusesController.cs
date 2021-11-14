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
    [Route("api/statuses")]
    [Produces("application/json")]
    public class StatusesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public StatusesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] StatusesFilters filters)
        {
            return Ok(_dataManager.Statuses.GetCountStatuses(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Statuses.GetNamesStatuses(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Status[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Statuses.GetStatuses().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Status[]), 200)]
        public IActionResult Index([FromBody] StatusesFilters filters)
        {
            return Ok(_dataManager.Statuses.GetStatuses(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Statuses.ContainsStatus(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Status), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Statuses.GetStatus(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Status status)
        {
            if (status.Id == default)
            {
                if (_dataManager.Statuses.SaveStatus(status))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = status.Id,
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
        public IActionResult Update([FromBody] Status status)
        {
            if (status.Id != default)
            {
                if (_dataManager.Statuses.SaveStatus(status))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = status.Id,
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
            _dataManager.Statuses.DeleteStatus(id);

            return Ok();
        }
    }
}
