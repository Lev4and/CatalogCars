using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/bodyTypes")]
    [Produces("application/json")]
    public class BodyTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public BodyTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetCountBodyTypes(filters));
        }

        [HttpPost("byBodyTypeGroupsIds/count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult CountBodyTypesOfBodyTypeGroups([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetCountBodyTypesOfBodyTypeGroups(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.BodyTypes.GetNamesBodyTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(BodyType[]), 200)]
        public IActionResult Index([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetBodyTypes(filters).ToArray());
        }

        [HttpGet("byBodyTypeGroupsIds")]
        [ProducesResponseType(typeof(BodyType[]), 200)]
        public IActionResult BodyTypesOfBodyTypeGroups([FromQuery(Name = "bodyTypeGroupId")] List<Guid> bodyTypeGroupsIds)
        {
            return Ok(_dataManager.BodyTypes.GetBodyTypesOfBodyTypeGroups(bodyTypeGroupsIds).ToArray());
        }

        [HttpPost("byBodyTypeGroupsIds")]
        [ProducesResponseType(typeof(BodyType[]), 200)]
        public IActionResult BodyTypesOfBodyTypeGroups([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetBodyTypesOfBodyTypeGroups(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid bodyTypeGroupId, [FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.BodyTypes.ContainsBodyType(bodyTypeGroupId, name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BodyType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.BodyTypes.GetBodyType(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] BodyType bodyType)
        {
            if (bodyType.Id == default)
            {
                if (_dataManager.BodyTypes.SaveBodyType(bodyType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = bodyType.Id,
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
        public IActionResult Update([FromBody] BodyType bodyType)
        {
            if (bodyType.Id != default)
            {
                if (_dataManager.BodyTypes.SaveBodyType(bodyType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = bodyType.Id,
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
            _dataManager.BodyTypes.DeleteBodyType(id);

            return Ok();
        }
    }
}
