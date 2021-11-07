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
    [Route("api/ptsTypes")]
    [Produces("application/json")]
    public class PtsTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PtsTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PtsTypesFilters filters)
        {
            return Ok(_dataManager.PtsTypes.GetCountPtsTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.PtsTypes.GetNamesPtsTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PtsType[]), 200)]
        public IActionResult Index([FromBody] PtsTypesFilters filters)
        {
            return Ok(_dataManager.PtsTypes.GetPtsTypes(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.PtsTypes.ContainsPtsType(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PtsType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.PtsTypes.GetPtsType(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] PtsType ptsType)
        {
            if (ptsType.Id == default)
            {
                if (_dataManager.PtsTypes.SavePtsType(ptsType))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = ptsType.Id,
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
        public IActionResult Update([FromBody] PtsType ptsType)
        {
            if (ptsType.Id != default)
            {
                if (_dataManager.PtsTypes.SavePtsType(ptsType))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = ptsType.Id,
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
            _dataManager.PtsTypes.DeletePtsType(id);

            return Ok();
        }
    }
}
