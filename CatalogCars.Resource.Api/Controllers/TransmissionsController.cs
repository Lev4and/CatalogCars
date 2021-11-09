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
    [Route("api/transmissions")]
    [Produces("application/json")]
    public class TransmissionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public TransmissionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] TransmissionsFilters filters)
        {
            return Ok(_dataManager.Transmissions.GetCountTransmissions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Transmissions.GetNamesTransmissions(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Transmission[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Transmissions.GetTransmissions().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Transmission[]), 200)]
        public IActionResult Index([FromBody] TransmissionsFilters filters)
        {
            return Ok(_dataManager.Transmissions.GetTransmissions(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Transmissions.ContainsTransmission(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Transmission), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Transmissions.GetTransmission(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Transmission transmission)
        {
            if (transmission.Id == default)
            {
                if (_dataManager.Transmissions.SaveTransmission(transmission))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = transmission.Id,
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
        public IActionResult Update([FromBody] Transmission transmission)
        {
            if (transmission.Id != default)
            {
                if (_dataManager.Transmissions.SaveTransmission(transmission))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = transmission.Id,
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
            _dataManager.Transmissions.DeleteTransmission(id);

            return Ok();
        }
    }
}
